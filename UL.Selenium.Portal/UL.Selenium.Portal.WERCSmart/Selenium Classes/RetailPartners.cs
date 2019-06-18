using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class RetailPartners : BaseObject
	{
		public const string BasePath = "//div[@id='retailPartners']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

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
			List<string> AdditionalDataConsentRequests = new List<string>();
			var MyDataAndRecipients = this.containerElement.FindElements(By.XPath(".//h2"), 2).FirstOrDefault(x => x.Text.Contains("My Data & Recipients"));
			if (MyDataAndRecipients != null)
			{
				AdditionalDataConsentRequests = MyDataAndRecipients.FindElements(By.XPath("../ div[2]//a//span")).Select(x => x.Text).ToList();
			}

			return AdditionalDataConsentRequests;
		}

		public bool RetailerShowingInAdditionalDataConsentRequests(string retailer)
		{
			List<string> AdditionalDataConsentRequests = new List<string>();
			var MyDataAndRecipients = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//h2"), 2).FirstOrDefault(x => x.Text.Contains("My Data & Recipients"));
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
			var recentPartners = this.containerElement.FindElements(By.XPath(".//div[@class='most-recent']//span[@class='sr-only']"), 2);
			if (recentPartners.Any(x => x.Text.ToLower().Contains(retailer.ToLower())))
			{
				// Retailer was found in the most recent retailer portion of the screen!
				return recentPartners.FirstOrDefault(x => x.Text.ToLower().Contains(retailer.ToLower())).FindElement(By.XPath("../.."), 2).TryClick();
			}
			// Retailer not found in the most recent retailers portion, so checking the rest of the retailers
			var allPartners = this.containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//span[@class='sr-only']"), 2);
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
				var el = this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]/a"), 2).ToList()[tile - 1];
				var backgorundImage = el.GetCssValue("background-image");
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
			var el = this.containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]//span[@class='sr-only']"), 2).ToList()[tile - 1];
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
	}

	class RetailParntersDetails : BaseObject
	{
		public const string BasePath = "//div[@id='retailDetails']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool HeaderShowing(string header, bool exact = true)
		{
			var headers = this.containerElement.FindElements(By.XPath(".//h3"), 2);
			return headers.Any(x => x.Text.Contains(header));
		}

		public string GetSectionText(string section)
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'panel') and (./preceding-sibling::h3[text()='" + section + "'])]"), 2).Text;
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
			var chart = this.containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//*[name()='svg']"), 2);
			if (chart == null)
			{
				return null;
			}
			var chartSector = chart.FindElement(By.XPath(".//*[name()='path' and @class='highcharts-point highcharts-color-0']"), 2);
			if (chartSector == null)
			{
				return null;
			}
			return chartSector.GetAttribute("fill");
		}

		public string ChartCentrePercentage()
		{
			var el = this.containerElement.FindElement(By.XPath(".//div[@id='total-products']"), 2);
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
			var el = this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.tierMoreInformation')]"), 2);
			return el != null && el.Displayed;
		}

		public void ClickProductsInScope()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@data-bind,'tiersControl.getReport')]"), 2).TryClick();
		}

		public bool ClickBackButton()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='header-with-back']//a/i"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
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
				return this.containerElement
					.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody//tr/td"), 2).Select(x => x.Text)
					.ToList().Where(x => x.Length > 0).ToList();
			}
			catch (Exception e)
			{
				return new List<string>();
			}

		}

		public bool SetDataConsentTier(string tier, bool trueFalse)
		{
			var dataConsentRows = this.DataConsentTiersTable()?.FindElements(By.XPath(".//tbody//tr"), 2);
			var correctRow = dataConsentRows?.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow == null)
			{
				return false;
			}
			var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
			var Checked = checkbox.Selected;
			return Checked == trueFalse || correctRow.FindElement(By.XPath(".//label[@class='switch']"), 2).TryClick() && checkbox.Selected == trueFalse;
		}

		public bool GetDataConsentTier(string tier)
		{
			var dataConsentRows = this.DataConsentTiersTable()?.FindElements(By.XPath(".//tbody//tr"), 2);
			var correctRow = dataConsentRows?.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow == null)
			{
				return false;
			}
			var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
			var Checked = checkbox.Selected;
			return Checked;
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
			var messages = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'alert-warning') and contains(@data-bind,'additionalInfo')]/p"), 2);
			if (messages.Count == 0)
			{
				return new List<string>();
			}
			return messages.Select(x => x.Text.Trim()).ToList();
		}

		public string GetSelectedRetailer()
		{
			return this.containerElement.FindElement(By.XPath("//h2[@id='retailerLabel']"), 2).GetElementText();
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
			var xPath = ".//p[contains(text(),'Walmart registrations')]/following-sibling::ul/li";
			return this.containerElement.FindElements(By.XPath(xPath), 2).Select(x => x.Text.Trim()).ToList();
		}

		public IWebElement DataConsentTiersTable()
		{
			return this.containerElement.FindElement(By.XPath(".//table[./thead/tr/th[text()='Data Consent Tiers']]"), 2);
		}

		public List<Supplier> GetAllSuppliers()
		{
			List<Supplier> supplierList = new List<Supplier>();
			var supplierTable = this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2);
			if (supplierTable == null)
			{
				Report.Info("Supplier table has not been found or is empty");
				return supplierList;
			}

			var supplierRows = supplierTable.FindElements(By.XPath(".//tbody/tr"));

			foreach (var thisRow in supplierRows)
			{
				Supplier newSupplier = new Supplier();
				newSupplier.SupplierID = thisRow.FindElement(By.XPath(".//td[1]"), 2).GetValue();
				newSupplier.CompanyOrBrandName = thisRow.FindElement(By.XPath(".//td[2]"), 2).GetValue();
				newSupplier.IsActive = thisRow.FindElement(By.XPath(".//td[3]/i"), 2).GetAttribute("class")
					.Contains("success");
				newSupplier.IsDefault = thisRow.FindElement(By.XPath(".//td[4]/i"), 2).GetAttribute("class")
					.Contains("success");

				supplierList.Add(newSupplier);

			}

			return supplierList;
		}

		public bool ClickActionBySupplierID(string sSupplierID, string action = "Deactivate")
		{
			try
			{
				var supplierTable = this.containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2);
				if (supplierTable == null)
				{
					Report.Info("Supplier table has not been found or is empty");
					return false;
				}

				var supplierRows = supplierTable.FindElements(By.XPath(".//tbody/tr"));

				foreach (var thisRow in supplierRows)
				{
					string SupplierID = thisRow.FindElement(By.XPath(".//td[1]"), 2).GetValue();
					if (sSupplierID == SupplierID)
					{
						if (thisRow.FindElement(By.XPath(".//td[5]//button"), 2).TryClick())
						{
							Delay.Seconds(0.5);
							var listActions = thisRow.FindElements(By.XPath(".//td[5]//a"));
							var matchingAction = listActions.FirstOrDefault(x => x.GetValue().Contains(action));
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
	}

	public class DataEntryNotification : BaseObject
	{
		public const string BasePath = "//div[@id='dataEntryNotifications']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Close']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool ClickOK()
		{
			return this.containerElement.FindElement(By.XPath(".//button[text()='Ok']"), 2).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}


	}

	public class ReportDownload : BaseObject
	{
		public const string BasePath = "//div[@id='download-modal']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//a[text()='Close']"), 2).TryClick();
		}


	}

	public class DataTierDetails : BaseObject
	{
		public const string BasePath = "//div[@class='modal in' and @id='data-tiers-details']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

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
			var chars_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var chars_a = chars_A.ToLower();
			var rList = new List<KeyValuePair<string, string>>();
			var ol_A = this.containerElement.FindElement(By.XPath("//div[@class='tab-pane active']//ol[@type='A']"), 2);
			string section = "";
			// Get the paragraph/ section elements for A, B...
			var lis_A = ol_A.FindElements(By.XPath("./li"));
			for (int i = 0; i < lis_A.Count; i++)
			{
				var li_A = lis_A[i];
				section = chars_A[i].ToString();
				rList.Add(new KeyValuePair<string, string>(section, li_A.Text.Trim()));
				// Look for child ol (section 1, 2...)
				var ol_1 = li_A.FindElement(By.XPath("./ol[@type='1']"), 2);
				if (ol_1 == null)
				{
					// Then the tree ends at A,B..
					continue;
				}
				// Get the paragraph/ section elements for (A/B)1, (A/B)2...
				var lis_1 = ol_1.FindElements(By.XPath("./li"));
				for (int j = 0; j < lis_1.Count; j++)
				{
					section = chars_A[i].ToString() + (j + 1);
					var li_1 = lis_1[j];
					rList.Add(new KeyValuePair<string, string>(section, li_1.Text.Trim()));
					// Look for child ol (a, b...)
					var ol_a = li_1.FindElement(By.XPath("./ol"), 2);
					if (ol_a == null)
					{
						// Then the tree ends at (A/B)1, (A/B)2..
						continue;
					}
					// Get the paragraph/ section elements for (A/B)1, (A/B)2...
					var lis_a = ol_a.FindElements(By.XPath("./li"));
					for (int k = 0; k < lis_a.Count; k++)
					{
						section = chars_A[i].ToString() + (j + 1) + chars_a[k];
						var li_a = lis_a[k];
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

	public class Supplier
	{
		public string SupplierID { get; set; }
		public string CompanyOrBrandName { get; set; }
		public bool IsActive { get; set; }
		public bool IsDefault { get; set; }
	}

}

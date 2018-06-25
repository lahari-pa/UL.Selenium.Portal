using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
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
			var MyDataAndRecipients = containerElement.FindElements(By.XPath(".//h2"), 2).FirstOrDefault(x => x.Text.Contains("My Data & Recipients"));
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
				recentPartners.FirstOrDefault(x => x.Text.Contains(retailer)).FindElement(By.XPath("../.."), 2).Click();
				return true;
			}

			// Retailer not found in the most recent retailers portion, so checking the rest of the retailers
			var allPartners = this.containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//span[@class='sr-only']"), 2);

			if (allPartners.Any(x => x.Text.ToLower().Contains(retailer.ToLower())))
			{
				// Retailer was found in the most recent retailer portion of the screen!
				allPartners.FirstOrDefault(x => x.Text.ToLower().Contains(retailer.ToLower())).FindElement(By.XPath("../.."), 2).Click();
				return true;
			}

			// Retailer not found!

			return false;
		}

		public bool ClickRetailerLogo(string retailerCode)
		{
			return containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col')]//a"), 2).FirstOrDefault(x => x.GetCssValue("background-image").ToLower().Contains(retailerCode.ToLower())).TryClick() && GeneralUtilities.Wait_for_load_finish();
		}

		public bool NoRetailerTilesAreEmpty()
		{
			return !containerElement.FindElements(By.XPath(".//div[@class='all-retailers']//div[starts-with(@class,'col') and not(.//a)]"), 2).Any();
		}

		public List<string> GetAllAvailableRetailers()
		{
			return containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col')]//a"), 2).Select(x => x.GetCssValue("background-image").Replace(@"""", "").Replace("url(", "").Replace(")", "")).ToList();
		}
		public bool TilesAppearBelowHeading(string heading)
		{
			return containerElement.FindElements(By.XPath(".//div[starts-with(@class,'col-sm-3') and ../parent::div[@class='" + heading + "']]")).Any();
		}

		public List<string> AllRetailerTilesBelowHeading(string heading)
		{
			return containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3') and ../parent::div[@class='" + heading + "']]//span[@class='sr-only']")).Select(x => x.Text).ToList();
		}
		public bool RetailerImageDisplayed(int tile)
		{
			var el = containerElement.FindElement(By.XPath(@".//div[starts-with(@class,'col-sm-3')][" + tile + "]/a"));
			var backgorundImage = el.GetCssValue("background-image");
			el.ScrollElementIntoView();
			return backgorundImage != "none";
		}

		public bool RetailerTextDisplayed(int tile)
		{
			var el = containerElement.FindElement(By.XPath(@".//div[starts-with(@class,'col-sm-3')][" + tile + "]//span[@class='sr-only']"));
			return el.Displayed;
		}

		public List<string> AllRetailerNames()
		{
			return containerElement.FindElements(By.XPath(@".//div[starts-with(@class,'col-sm-3')]//span[@class='sr-only']")).Select(x => x.Text).ToList();
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
			return containerElement.FindElement(By.XPath(".//div[contains(@class,'panel') and (./preceding-sibling::h3[text()='" + section + "'])]"), 2).Text;
		}

		public bool SupplierIDTableShowing()
		{
			return containerElement.FindElement(By.XPath(".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table"), 2) != null;
		}

		public string GetChartLegend()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='chart-legend']"), 2).Text;
		}

		public bool PieChartShowing()
		{
			return containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//*[name()='svg']"), 2) != null;
		}

		public string GetPieChartFooterText()
		{
			return containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//div[@class='chart-legend']/p"), 2).Text;
		}

		public string ChartRetailerFill()
		{
			var chart = containerElement.FindElement(By.XPath(".//h3[contains(normalize-space(),'& You')]//following-sibling::div//*[name()='svg']"), 2);
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
			var el = containerElement.FindElement(By.XPath(".//div[@id='total-products']"), 2);
			if (el == null)
			{
				return null;
			}
			return el.Text;
		}

		public string GetAndYouText()
		{
			return containerElement.FindElement(By.XPath(".//div[@class='chart-legend']/../../..//h3"), 2).Text;
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
			var dataConsentRows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody//tr"), 2);
			var correctRow = dataConsentRows.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow != null)
			{
				var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
				var Checked = checkbox.Selected;
				if (Checked != trueFalse)
				{
					correctRow.FindElement(By.XPath(".//label[@class='switch']"), 2).Click();
				}

				return true;
			}
			return false;
		}

		public bool GetDataConsentTier(string tier)
		{
			var dataConsentRows = this.containerElement.FindElements(By.XPath(".//div[contains(@class,'data-consent')]//table//tbody//tr"), 2);
			var correctRow = dataConsentRows.FirstOrDefault(x => x.FindElement(By.XPath(".//td[1]"), 2).Text.StartsWith(tier));
			if (correctRow != null)
			{
				var checkbox = correctRow.FindElement(By.XPath(".//input[@type='checkbox']"), 2);
				var Checked = checkbox.Selected;
				return Checked;
			}
			return false;
		}

		public bool SaveChangesButtonShowing()
		{
			return this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn')]"), 2).Displayed;
		}


		public bool ClickSaveChanges()
		{
			var el = this.containerElement.FindElement(By.XPath(".//p/a[contains(@class,'btn')]"), 2);
			if (el == null)
			{
				return false;
			}

			try
			{
				el.Click();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string WarningMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//div[contains(@class,'alert-warning') and contains(@data-bind,'additionalInfo')]"), 2).Text;
		}

		public string GetSelectedRetailer()
		{
			return containerElement.FindElement(By.XPath("//h2[@id='retailerLabel']"), 2).GetElementText();
		}

		public List<string> GetButtons(string section)
		{
			return containerElement.FindElements(By.XPath(".//div[contains(@class,'panel') and (./preceding-sibling::h3[text()='" + section + "'])]//ul[contains(@class,'list')]//a"), 2).Select(x => x.Text).ToList();
		}

		public List<string> GetSupplierIDTableHeaders()
		{
			return containerElement
				.FindElements(
					By.XPath(
						".//h3[text()='Your Supplier IDs']//following-sibling::div[contains(@class,'supplier')]//table/thead/tr/th"),
					2).Select(x => x.Text).Select(x => x.Trim()).ToList();
		}

		public bool ClickAddSupplierId()
		{
			return containerElement.FindElement(By.XPath(".//a[@class='add-supplier-id']")).TryClick();
		}

		public List<string> WalmartRegistrationsRetailers()
		{
			var xPath = ".//p[contains(text(),'Walmart registrations')]/following-sibling::ul/li";
			return containerElement.FindElements(By.XPath(xPath), 2).Select(x => x.Text.Trim()).ToList();
		}
	}

	public class DataEntryNotification : BaseObject
	{
		public const string BasePath = "//div[@id='dataEntryNotifications']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void ClickClose()
		{
			this.containerElement.FindElement(By.XPath(".//button[text()='Close']"), 2).TryClick();
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

}

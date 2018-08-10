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
	class StudioSHAManager : BaseObject
	{
		public const string BasePath = "//iframe[@id='Widget1FRAME']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForProductList(int secondsToWait)
		{
			Report.Info("Beginning wait for product list");
			if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
			{
				SeleniumBrowser.ExitIFrame();
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					Report.Error("Could not switch to iframe");
				}
			}
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[@id='list']")) != null)
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

		public bool WaitForIDToTurnBlue(string id, int secondsToWait)
		{
			//get index of id column
			int index = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a=>a=="Product");
			for(int i = 0;i < secondsToWait; i++)
			{
				var matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (index+1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);

				string colour = matchingTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();
				if ( colour == "rgba(0, 0, 255, 1)")
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public List<Product> GetTopXProducts(int topX)
		{
			var ListOfProductRows =
				SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//table[@id='list']//tr"));

			List<string> ListOfHeaders = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x=>x.GetValue().Trim()).ToList();
			List<Product> ListOfProducts = new List<Product>();

			//ignore first row because it is empty
			for (int j = 1; j < Math.Min(ListOfProductRows.Count, topX+1); j++)
			{
				Product thisProduct = new Product();
				//start indexing from 1 because the first column is a checkbox
				int addIndex = 1;
				for (int i = 0; i < ListOfHeaders.Count(); i++)
				{
					switch (ListOfHeaders[i])
					{
						case "Product":
							string pValue = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue();
							if (pValue.Trim().Length != 0)
							{
								thisProduct.ID = pValue.Trim();
							}
							break;
						case "Name":
							string pName = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							if (pName.Trim().Length != 0)
							{
								thisProduct.Name = pName;
							}
							break;
						case "Supplier":
							thisProduct.Supplier = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "User":
							thisProduct.User = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "Status":
							thisProduct.Status = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "Original Submission":
							string pOS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							if (pOS.Length > 0)
							{
								thisProduct.OriginalSubmission = Convert.ToDateTime(pOS);
							}
							break;
						case "Current Submission":
							string pCS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							if (pCS.Length > 0)
							{
								thisProduct.CurrentSubmission = Convert.ToDateTime(pCS);
							}
							break;
						case "Last ActivityDate":
							string pAD = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							if (pAD.Length > 0)
							{
								thisProduct.LastActivityDate = Convert.ToDateTime(pAD);
							}
							break;
						case "Due Date":
							string pDD = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							if (pDD.Length > 0)
							{
								thisProduct.DueDate = Convert.ToDateTime(pDD);
							}
							break;
						case "Reviewer":
							thisProduct.Reviewer = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "SDS":
							thisProduct.SDS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim()=="Yes";
							break;
						case "Canada SDS":
							thisProduct.CanadaSDS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim()=="Yes";
							break;
						case "Clients":
							thisProduct.Clients = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "T. Reg":
							thisProduct.TReg = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim()=="Yes";
							break;
						case "Last Pub Date":
							thisProduct.LastPubDate = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "GHS":
							thisProduct.GHS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "Refeed":
							thisProduct.Refeed = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim()=="Yes";
							break;
						default:
							//ignore this column, either empty or not of interest
							break;

					}
				}

				ListOfProducts.Add(thisProduct);
			}

			return ListOfProducts;
		}

		public bool TopRowProductsTableMatchesId(string id)
		{
			return GetTopXProducts(1).FirstOrDefault().ID == id;
		}

		
		public bool ClickTopMenuItem(string option)
		{
			try
			{
				var ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='ddtopmenubar']/ul/li/a"));
				IWebElement menuOption = ListOfTopMenuOptions.FirstOrDefault(x => x.Text.ToLower() == option.ToLower());
				return menuOption.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

			return false;
		}

		public bool ClickActionsMenuOption(string option)
		{
			try
			{
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					SeleniumBrowser.ExitIFrame();
					if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
					{
						Report.Info("Couuld not switch to iframe");
						return false;
					}
				}
				var ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//ul[@id='ddsubmenu1']/li/a"));
				IWebElement menuOption = ListOfTopMenuOptions.FirstOrDefault(x => x.GetValue(true).ToLower() == option.ToLower());
				Report.Info("Found options: " + string.Join(",", ListOfTopMenuOptions.Select(x => x.GetValue(true)).ToList()));
				if (menuOption != null)
				{
					return menuOption.TryClick(Click_Functionality.ClickType.JavaScript);
				}
				else
				{
					Report.Info("Matching menu option has not been found");
					return false;
				}

			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return false;
			}

		}

		public bool SelectFromStatusFilter(string option)
		{
			try
			{
				var statusSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//select[@id='status']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		//Delete, Search (Srch), Status, Reject Submission, Create Group, Review
		public bool ClickBottomMenuOption(string option)
		{
			if (option.ToLower() == "search")
			{
				option = "Srch";
			}
			var listOfOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[contains(@class,'navtable')]//td[not(contains(@class, 'disabled')) and not(contains(@style, 'none'))]/div"));
			var matchingOption = listOfOptions.FirstOrDefault(x => x.GetValue().ToLower().Contains(option.ToLower()));
			
			if (matchingOption == null)
			{
				Report.Info("No matching menu option found: " + option + ". Available options: " + string.Join(",", listOfOptions));
				return false;
			}

			return matchingOption.TryClick();
		}
	}

	class StudioSHAManagerProductSearch : BaseObject
	{
		public const string BasePath = "//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool SelectStatus(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='searchstatus']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}

			return false;
		}

		public bool SelectFromStatusFilter(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='searchstatus']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool SelectFromClientFilter(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='searchclient']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool SelectFromSearchPatternFilter(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='drpSearchPattern']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool SelectFromDateRangeFilter(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='ddFilterByDateType']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool SelectFromTRegFilter(string option)
		{
			try
			{
				var statusSelect = containerElement.FindElement(By.XPath(".//select[@id='ddTReg']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool EnterProductID(string iD)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchProduct']"));
			enterField.EnterText(iD);
			return (enterField.GetValue() == iD);
		}

		public bool EnterProductName(string name)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchName']"));
			enterField.EnterText(name);
			return (enterField.GetValue() == name);
		}

		//format - mm/dd/yy
		public bool EnterLastActivityDate(string date)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtLastDate']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterDateFrom(string date)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='fromDatepicker']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterDateTo(string date)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='toDatepicker']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterSubmissionDate(string date)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchDate']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterSupplier(string supplier)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchSupplier']"));
			enterField.EnterText(supplier);
			return (enterField.GetValue() == supplier);
		}

		public bool EnterUPC(string upc)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchUPC']"));
			enterField.EnterText(upc);
			return (enterField.GetValue() == upc);
		}

		public bool EnterParentUPC(string upc)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchPUPC']"));
			enterField.EnterText(upc);
			return (enterField.GetValue() == upc);
		}

		public bool EnterUser(string user)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchUser']"));
			enterField.EnterText(user);
			return (enterField.GetValue() == user);
		}

		public bool EnterReviewer(string user)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchReviewer']"));
			enterField.EnterText(user);
			return (enterField.GetValue() == user);
		}

		public bool EnterOrderNo(string orderNo)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='txtSearchOrder']"));
			enterField.EnterText(orderNo);
			return (enterField.GetValue() == orderNo);
		}

		public bool CheckOnSuspended(bool check)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='chkOnHold']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckRecertificationActive(bool check)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='chkIsRecertActive']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckGoodGuideOnlyProducts(bool check)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='chkGGOnly']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckECommFlowProducts(bool check)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='chkeCommProduct']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool ClickButton(string button)
		{
			var buttonList = containerElement.FindElements(By.XPath(".//button"));
			var matchingButton = buttonList.FirstOrDefault(x => x.FindElement(By.XPath(".//span")).GetValue().Trim() == button);
			if (matchingButton == null)
			{
				Report.Info("no matching button was found");
				return false;
			}
			else
			{
				return matchingButton.TryClick();
			}
		}

		
	}

	class Product
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Supplier { get; set; }
		public string User { get; set; }
		public string Status { get; set; }
		public DateTime OriginalSubmission { get; set; }
		public DateTime CurrentSubmission { get; set; }
		public DateTime LastActivityDate { get; set; }
		public DateTime DueDate { get; set; }
		public string Reviewer { get; set; }
		public bool SDS { get; set; }
		public bool CanadaSDS { get; set; }
		public string Clients { get; set; }
		public bool TReg { get; set; }
		public string GHS { get; set; }
		public string LastPubDate { get; set; }
		public bool Refeed { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
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
		public const string BasePath = "//div[@id='main']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			//get the window
			StudioUtilites.SwitchToWindow("Wercs Studio");
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
			IWebElement frame =
				SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='Widget1']//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			return base.Wait_for_load(30);
		}

		public bool WaitForProductList(int secondsToWait)
		{
			SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
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
					var table = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//table[@id='list']"), 60);
					if (table != null)
					{
						if (table.Displayed || table.FindElements(By.XPath(".//tr")).Count == 1)
						{
							return true;
						}
					}
				}
				catch (Exception e)
				{
					Report.Error("Caught error" + e.Message);
					continue;
					//do nothing
				}

				Delay.Seconds(1);
				i++;
			}

			Report.Info($"Product list was not loaded after {secondsToWait} seconds!");
			return false;
		}

		public ProductStatus GetproductStatus(string id)
		{
			ProductStatus thisProductStatus = new ProductStatus();
			Report.Info("Beginning get product status by id: " + id);

			try
			{
				int idIndex = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

				StudioSHAManager mySHAManager = new StudioSHAManager();
				mySHAManager.Wait_for_load();
				var matchingProduct = mySHAManager.GetTopXProducts(1).FirstOrDefault(x => x.ID == id);

				if (matchingProduct == null)
				{
					mySHAManager.ClickBottomMenuOption("search");
					StudioSHAManagerProductSearch myProductSearch = new StudioSHAManagerProductSearch();
					myProductSearch.Wait_for_load(3);
					myProductSearch.EnterProductID(id);
					myProductSearch.SelectFromStatusFilter("All");
					Report.Screenshot();
					if (!myProductSearch.ClickButton("Find"))
					{
						if (!myProductSearch.ClickButton("Find"))
						{
							throw new Exception("Failed to click the find button");
						}
					}

					Delay.Seconds(1);
					if (myProductSearch.Wait_for_load(1))
					{
						Report.Info("Product search popup has not closed");
						if (!myProductSearch.ClickButton("Cancel"))
						{
							throw new Exception("Failed to click the cancel button");
						}

						Delay.Seconds(1);
					}

					if (myProductSearch.Wait_for_load(1))
					{
						throw new Exception("Failed to close the product search popup");
					}

					if (!mySHAManager.WaitForProductList(30))
					{
						throw new Exception("Product list is not showing as expected");
					}

					Report.Info("Product list is showing");
				}

				var matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (idIndex + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);
				var matchingSpan = matchingTD.FindElement(By.XPath(".//span"));
				string colour = matchingTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();

				thisProductStatus.CSSColour = colour;
				thisProductStatus.CSSBackgroundColor = matchingSpan.GetCssValue("background-color");
				thisProductStatus.Bold = matchingSpan.GetAttribute("class").ToLower().Contains("bold");
				thisProductStatus.StatusName = matchingSpan.GetAttribute("class")
					.Replace("bold", "", StringComparison.InvariantCultureIgnoreCase).Trim();

			}
			catch (Exception e)
			{
				return null;
			}

			return thisProductStatus;
		}

		//idStatus - tPartyForm, hold, elect, brandedcomp, docrequest, batt, kit, rulerunning, rulequeue, ruleerror, feederror,
		public bool WaitForIDToBeStatus(string id, int secondsToWait, string tableStatus, string idStatus, bool expectingBold = false, string tableBackground = "none")
		{
			Report.Info("Beginning wait for id to be status");
			var myProductSearch = new StudioSHAManagerProductSearch();
			for (int i = 0; i < secondsToWait; i++)
			{
				var mySHAManager = new StudioSHAManager();
				mySHAManager.ClickBottomMenuOption("search");
				myProductSearch.Wait_for_load(3);
				myProductSearch.EnterProductID(id);
				myProductSearch.SelectFromStatusFilter("All");
				Report.Screenshot();
				if (!myProductSearch.ClickButton("Find"))
				{
					if (!myProductSearch.ClickButton("Find"))
					{
						throw new Exception("Failed to click the find button");
					}
				}

				Delay.Seconds(1);
				if (myProductSearch.Wait_for_load(1))
				{
					Report.Info("Product search popup has not closed");
					if (!myProductSearch.ClickButton("Cancel"))
					{
						throw new Exception("Failed to click the cancel button");
					}

					Delay.Seconds(1);
				}

				if (myProductSearch.Wait_for_load(1))
				{
					throw new Exception("Failed to close the product search popup");
				}

				if (!mySHAManager.WaitForProductList(30))
				{
					throw new Exception("Product list is not showing as expected");
				}

				Report.Info("Product list is showing");
				var thisProductStatus = this.GetproductStatus(id);
				if (thisProductStatus != null)
				{
					if ((idStatus == thisProductStatus.StatusName || idStatus.ToLower() == "n/a") && thisProductStatus.Bold == expectingBold &&
						(tableBackground == "none" || tableBackground == thisProductStatus.CSSBackgroundColor))
					{
						return true;
					}

					var matchReport = "";
					if (idStatus == thisProductStatus.StatusName)
					{
						matchReport += " status matched";
					}
					else
					{
						matchReport += " status did not match. Expecting: " + idStatus + " but got: " + thisProductStatus.StatusName;
					}

					if (thisProductStatus.Bold == expectingBold)
					{
						matchReport += " bolding matched";
					}
					else
					{
						matchReport += " bolding did not match. Expecting: " + expectingBold.ToString() + " but got: " + thisProductStatus.Bold.ToString();
					}

					if (tableBackground == "none" || tableBackground == thisProductStatus.CSSBackgroundColor)
					{
						matchReport += " background as expected";
					}
					else
					{
						matchReport += " background not as expected";
					}

					Report.Info(matchReport);
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public string ProductHighlight(string id)
		{
			Report.Info("Checking product background colour");
			var myProductSearch = new StudioSHAManagerProductSearch();
			var mySHAManager = new StudioSHAManager();
			mySHAManager.ClickBottomMenuOption("search");
			myProductSearch.Wait_for_load(3);
			myProductSearch.EnterProductID(id);
			myProductSearch.SelectFromStatusFilter("All");
			Report.Screenshot();
			var thisProductStatus = this.GetproductStatus(id);
			if (thisProductStatus != null)
			{
				return thisProductStatus.CSSBackgroundColor;
			}

			Report.Info("Failed to get product status for id: " + id);
			return null;
		}

		public bool WaitForIDToTurnBlue(string id, int secondsToWait)
		{
			//get index of id column
			int index = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			for (int i = 0; i < secondsToWait; i++)
			{
				StudioSHAManager mySHAManager = new StudioSHAManager();

				if (mySHAManager.GetCurrentStatusFilter() == "Assigned")
				{
					mySHAManager.SelectFromStatusFilter("All");
					StudioSHAManagerProductSearch myProductSearch = new StudioSHAManagerProductSearch();
					myProductSearch.Wait_for_load(3);
					myProductSearch.ClickButton("Find");
					mySHAManager.WaitForProductList(30);
				}
				else
				{
					mySHAManager.SelectFromStatusFilter("Assigned");
				}

				Delay.Seconds(5);
				var matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);

				string colour = matchingTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();
				if (colour == "rgba(0, 0, 255, 1)")
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool SelectProductByID(string id)
		{
			Delay.Seconds(3);
			Report.Info("Attemping to select product by id: " + id);
			int index = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

			var matchingTD = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
				.FirstOrDefault(x => x.GetValue().Trim() == id);

			if (matchingTD != null)
			{
				Report.Info("Found matching cell");
				matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);
				var checkbox = matchingTD.FindElement(By.XPath("../td/input"));
				Report.Info("Found checkbox");
				if (checkbox != null)
				{
					if (checkbox.Checked())
					{
						Report.Info("Checkbox is already checked");
						return true;
					}

					checkbox.TryClick();
					if (checkbox.Checked())
					{
						Report.Screenshot();
						return true;
					}
					else
					{
						Report.Info("Attempted to check checkbox but failed.");
						return false;
					}
				}
				else
				{
					Report.Info("Checkbox has not been found");
					matchingTD = SeleniumBrowser.WebBrowser
						.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
						.FirstOrDefault(x => x.GetValue().Trim() == id);
					checkbox = matchingTD.FindElement(By.XPath("../td/input"));
					if (checkbox != null)
					{
						checkbox.Check(true);
						Report.Screenshot();
						return true;
					}
					else
					{
						Report.Error("Checkbox has not been found");
					}
				}
			}
			else
			{
				Report.Info("Failed to find matching table cell for id: " + id);
			}

			return false;
		}

		public bool RightClickProductByID(string id)
		{
			Delay.Seconds(3);
			Report.Info("Attemping to rightclick product by id: " + id);
			int index = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

			var matchingTD = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
				.FirstOrDefault(x => x.GetValue().Trim() == id);

			if (matchingTD != null)
			{
				Report.Info("Found matching cell");
				matchingTD.RightClick();
				return true;
			}
			else
			{
				Report.Info("Failed to find matching table cell for id: " + id);
			}

			return false;
		}

		public bool ProductTableIsEmpty()
		{
			try
			{
				var ListOfProductRows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='list']//tr"), 3).ToList();
				if (ListOfProductRows == null || ListOfProductRows.Count == 1)
				{
					//count of 1 row means only headers so table is empty
					return true;
				}
			}
			catch (Exception e)
			{
				return true;
			}

			return false;
		}

		public List<Product> GetTopXProducts(int topX)
		{
			//Report.Info("Getting top " + topX.ToString() + " products");
			List<IWebElement> ListOfProductRows = null;

			if (this.ProductTableIsEmpty())
			{
				return new List<Product>();
			}

			ListOfProductRows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='list']//tr"), 3).ToList();

			//Report.Info("Got product rows: " + ListOfProductRows.Count.ToString());
			List<string> ListOfHeaders = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList();
			//Report.Info("Got list of headers");
			List<Product> ListOfProducts = new List<Product>();

			//ignore first row because it is empty
			for (int j = 1; j < Math.Min(ListOfProductRows.Count, topX + 1); j++)
			{
				//Report.Info("Looking at row: " + j.ToString());
				Product thisProduct = new Product();
				//start indexing from 1 because the first column is a checkbox
				int addIndex = 1;
				for (int i = 0; i < ListOfHeaders.Count(); i++)
				{
					//Report.Info("Looking at column: " + ListOfHeaders[i]);
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

							thisProduct.ColourRGB = ListOfProductRows[j]
								.FindElement(By.XPath(".//td[" + (i + addIndex) + "]")).GetCssValue("Color");
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
												  .GetValue().Trim() == "Yes";
							break;
						case "Canada SDS":
							thisProduct.CanadaSDS = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
														.GetValue().Trim() == "Yes";
							break;
						case "Clients":
							thisProduct.Clients = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
								.GetValue().Trim();
							break;
						case "T. Reg":
							thisProduct.TReg = ListOfProductRows[j].FindElement(By.XPath(".//td[" + (i + addIndex) + "]"))
												   .GetValue().Trim() == "Yes";
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
													 .GetValue().Trim() == "Yes";
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
			// JS. possible null exception - GetTopXProducts() can return a list with 0 items
			//return GetTopXProducts(1).FirstOrDefault().ID == id;
			var products = this.GetTopXProducts(1);
			if (products == null || products.Count == 0)
			{
				return false;
			}

			return products.FirstOrDefault().ID == id;
		}

		public bool ClickProcessProductData()
		{
			try
			{
				var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkProcess']"));
				return button.TryClick();
			}
			catch (Exception e)
			{
				Report.Error("process product data button was not found");
				return false;
			}

		}

		public bool ClickReports()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkReports']"));
			return button.TryClick();
		}

		public bool ClickExport()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkExport']"));
			return button.TryClick();
		}

		public bool ClickDataCodeExport()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkDataCodeExport']"));
			return button.TryClick();
		}

		public bool ClickAutoAssign()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkAutoAssign']"));
			return button.TryClick();
		}

		public bool SetAutoAssignRegulatorySpecialisttoProduct(bool set)
		{
			var enterField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='chkAutoAssignUser']"));
			enterField.Check(set);
			return enterField.Checked() == set;
		}

		public bool SelectRegulatorySpecialist(string name)
		{
			var select = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='regulatoryusers']"));
			select.Select(name);
			return (select.SelectedOption() == name);
		}

		public bool SetAutoRedirectToClientsIfConditionMatch(bool set)
		{
			var enterField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='chkAutoRedirect']"));
			enterField.Check(set);
			return enterField.Checked() == set;
		}

		public bool ClickContinueInProcessProducts()
		{
			var buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-product']/..//button"));
			var continueButton =
				buttons.FirstOrDefault(x => x.FindElement(By.XPath(".//span")).GetValue().Trim() == "Continue");
			if (continueButton != null)
			{
				return continueButton.TryClick();
			}

			return false;
		}

		public bool WaitForProductToAppearOnProcessedList(string id, int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var processedList =
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='dialog-product']//div[@id='message']"));
				var products = processedList.FindElements(By.XPath(".//span"));
				var matchingProduct = products.FirstOrDefault(x => x.GetValue().Trim().Contains(id));
				if (matchingProduct != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool ClickCloseInProcessProducts()
		{
			var buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-product']/..//button"));
			var closeButton =
				buttons.FirstOrDefault(x => x.FindElement(By.XPath(".//span")).GetValue().Trim() == "Close");
			if (closeButton != null)
			{
				return closeButton.TryClick();
			}

			return false;
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

		public string GetCurrentStatusFilter()
		{
			var statusSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='status']"));
			return statusSelect.SelectedOption();
		}

		public bool SelectFromStatusFilter(string option)
		{
			//Report.Info("Beinnign select from status filter: " + option);
			try
			{
				var statusSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='status']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception e)
			{
				Report.Info("Did not find status select");
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


		public List<SHAManagerProdcutUPC> GetUPCs()
		{
			var rList = new List<SHAManagerProdcutUPC>();
			var rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[not(@class='DarkBack')]"), 2);
			var headerRow = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//tr[@class='DarkBack']"), 2);
			if (headerRow == null)
			{
				Report.Info("Could not locate 'dark back' header row");
				return null;
			}

			var headers = headerRow.FindElements(By.XPath("./td"), 2);
			var upcPosition = headers.IndexOf(headerRow.FindElement(By.XPath("./td[contains(text(),'UPC Number')]"))) + 1;
			var pkgTypePosition = headers.IndexOf(headerRow.FindElement(By.XPath("./td[contains(text(),'Pkg Type')]"))) + 1;
			var pkgSizePosition = headers.IndexOf(headerRow.FindElement(By.XPath("./td[contains(text(),'Pkg Size')]"))) + 1;
			// IndexOf() returns -1 if el not found in the row. position()= 0 will fail to get the correct td
			if (upcPosition == 0 || pkgTypePosition == 0 || pkgSizePosition == 0)
			{
				Report.Info("Could not locate 'UPC Number', 'Pkg Type' or 'Pkg Size' in header row!");
				return null;
			}

			foreach (var row in rows)
			{
				var thisUpc = new SHAManagerProdcutUPC {
					UPCNumber = row.FindElement(By.XPath($"./td[position()= {upcPosition}]"), 2)?.Text,
					PackagingType = row.FindElement(By.XPath($"./td[position()= {pkgTypePosition}]"), 2)?.Text,
					PackagingSize = row.FindElement(By.XPath($"./td[position()= {pkgSizePosition}]"), 2)?.Text
				};
				rList.Add(thisUpc);
			}

			Report.Info($"Found {rList.Count} UPCs");
			return rList;
		}


		public bool ClickProcessRecertification()
		{
			try
			{
				var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkRecertification']"));
				return button.TryClick();
			}
			catch (Exception e)
			{
				Report.Error("process recertification button was not found");
				return false;
			}

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
			var buttonList = containerElement.FindElements(By.XPath(".//button/span"));
			var matchingButton = buttonList.FirstOrDefault(x => x.GetValue().Trim() == button);
			if (matchingButton == null)
			{
				matchingButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button/span[text()='Find']"), 2);
				if (matchingButton == null)
				{
					Report.Info("no matching button was found");
					return false;
				}
				return matchingButton.TryClick();
			}
			return matchingButton.TryClick();
		}


	}

	class ProcessProducts : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-status-update']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public List<string> GetAllRetailers()
		{
			var retailerSpan = containerElement.FindElement(By.XPath(".//input[@id='clients']/..")).GetInnerHTML();
			string regexSplitPattern = @"\<input\stype.*?value=.*?\>";

			List<string> Retailers = Regex.Split(retailerSpan, regexSplitPattern)
				.Select(x => Regex.Replace(x, regexSplitPattern, "").Replace("<br>", "").Trim()).ToList();

			return Retailers;
		}

		public bool SelectRetailer(string retailerName)
		{
			var retailerSpan = containerElement.FindElement(By.XPath(".//input[@id='clients']/..")).GetInnerHTML();
			List<string> splitOnBr = Regex.Split(retailerSpan, @"\<br\>").ToList();
			var matchingInputString = splitOnBr.FirstOrDefault(x => x.Contains(retailerName));

			string regexSplitPattern = @"value=(.*)\>";
			Regex regex = new Regex(regexSplitPattern);
			Match match = regex.Match(matchingInputString);
			if (match.Success)
			{
				string regexIDPattern =
					@"[a-z 0-9]{4,12}\-[a-z 0-9]{4,12}\-[a-z 0-9]{4,12}\-[a-z 0-9]{4,12}\-[a-z 0-9]{4,12}";
				regex = new Regex(regexIDPattern);
				Match matchID = regex.Match(match.Value);
				if (matchID.Success)
				{
					string validID = matchID.Value;
					var matchInput = containerElement.FindElement(By.XPath(".//input[@value='" + validID + "']"));
					if (matchInput != null)
					{
						return matchInput.TryCheck();
					}
					else
					{
						Report.Info("Failed to find matching input for value: " + validID);
					}
				}
				else
				{
					Report.Info("Failed to find match for regex pattern: " + regexIDPattern + " in string: " +
								match.Value);
				}
			}
			else
			{
				Report.Info("Failed to find match for regex pattern: " + regexSplitPattern + " in string: " +
							matchingInputString);
			}

			return false;
		}

		public bool SelectNewStatus(string status)
		{
			try
			{
				var statusDD = containerElement.FindElement(By.XPath(".//select[@id='statusupdate']"));
				statusDD.Select(status);
				return statusDD.SelectedOption() == status;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool ClickUpdateStatus()
		{
			try
			{
				var updateStatusButton = containerElement.FindElement(By.XPath(".//select[@id='statusupdate']/following-sibling::a"));
				return updateStatusButton.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool ClickRefeedToClient()
		{
			try
			{
				var refeedToClient = containerElement.FindElement(By.XPath(".//fieldset[@id='fldFeedClient']/a"));
				return refeedToClient.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

		}
	}

	class RightClickProductMenu : BaseObject
	{
		public const string BasePath = "//div[@id='jqContextMenu']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool MenuExists()
		{
			return containerElement.Displayed;
		}

		public List<string> GetAllOptions()
		{
			return containerElement.FindElements(By.XPath(".//li[not(contains(@style, 'none'))]")).Select(x => x.GetValue()).ToList();
		}

		public bool SelectOption(string selectOption)
		{
			var listOfOptions = containerElement.FindElements(By.XPath(".//li[not(contains(@style, 'none'))]"));
			var matchingOption = listOfOptions.FirstOrDefault(x => x.GetValue().Contains(selectOption));
			if (matchingOption == null)
			{
				List<string> Options = GetAllOptions();
				Report.Error("No matching option was found. Options were: " + string.Join(",", Options));
				return false;
			}

			return matchingOption.TryClick();
		}


	}

	class RecertificationPopup : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-recertification']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool WaitForLoad(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					if (this.PopupExists())
					{
						return true;
					}
				}
				catch (Exception e)
				{
					//do nothing
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool PopupExists()
		{
			return containerElement.Displayed;
		}

		public bool SetAutoAssignRegulatorySpecialistToProduct(bool setChecked)
		{
			var checkBox =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//div[@id='dialog-recertification']//input[@id='chkAutoAssignUserRecert']"), 2);

			if (checkBox != null)
			{
				if (checkBox.Checked())
				{
					if (setChecked)
					{
						Report.Info("Checkbox is already checked");
						return true;
					}
					else
					{
						return checkBox.TryClick();

					}
				}
				else
				{
					if (!setChecked)
					{
						Report.Info("Checkbox is already unchecked");
						return true;
					}
					else
					{
						return checkBox.TryClick();

					}
				}

			}

			return false;
		}

		public bool ClickButton(string buttonName)
		{
			var buttons =
				SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-recertification']/..//button"));

			var matchingButton =
				buttons.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetValue().Contains(buttonName));

			if (matchingButton == null)
			{
				Report.Info("Could not find button: " + buttonName);
				return false;
			}

			return matchingButton.TryClick();
		}

		public bool ButtonExists(string buttonName)
		{
			var buttons =
				SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-recertification']/..//button"));
			var matchingButton =
				buttons.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetValue().Contains(buttonName));

			if (matchingButton == null)
			{
				Report.Info("Could not find button: " + buttonName);
				return false;
			}

			return true;
		}

		public bool SelectRegulatorySpecialist(string specialistName)
		{
			var selectSpecialist =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//div[@id='dialog-recertification']//select[@id='regUsers']"), 2);

			if (selectSpecialist == null)
			{
				Report.Info("Select box was not found");
				return false;
			}

			var ListOfSpecialists = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath("//div[@id='dialog-recertification']//select[@id='regUsers']/option"), 2);

			var matchingItem = ListOfSpecialists.FirstOrDefault(x => x.GetValue().Contains(specialistName));

			if (matchingItem == null)
			{
				Report.Info("Specialist: " + specialistName + " was not found in the list", "Found specialist");
				return false;
			}

			return matchingItem.TryClick();
		}

		public bool WaitForProcessing(int secondsToWait)
		{
			string progress = "0";
			for (int i = 0; i < secondsToWait; i++)
			{
				var progressBar =
					SeleniumBrowser.WebBrowser.FindElement(
						By.XPath("//div[@id='dialog-recertification']//div[@id='progBarRecertification']"), 2);

				if (progressBar != null)
				{
					progress = progressBar.GetProperty("aria-valuenow");

					if (progress == "100")
					{
						return true;
					}
					else
					{
						Report.Info("Progress is: " + progress);
					}
				}
				else
				{
					Report.Info("Progress bar was not found");
					return false;
				}

				Delay.Seconds(1);
			}

			return false;

		}

		public List<string> GetProcessingMessages()
		{
			var progressMessage =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//div[@id='dialog-recertification']//span[@id='msgRecertification']"), 2);

			if (progressMessage == null)
			{
				Report.Info("Progress message was not found");
				return new List<string>();
			}

			var progressMessages = progressMessage.FindElements(By.XPath("./span"));
			if (progressMessages.Count == 0)
			{
				Report.Info("Progress messages not found");
				return new List<string>();
			}

			return progressMessages.Select(x => x.GetValue()).ToList();

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
		public string ColourRGB { get; set; }
		public bool Active { get; set; }
		public DateTime RecertificationDate { get; set; }
		public string RecertificationReason { get; set; }

	}

	class SHAManagerProdcutUPC
	{
		public string UPCNumber { get; set; }
		public string PackagingType { get; set; }
		public string PackagingSize { get; set; }
	}

	class ProcessUIDialog : BaseObject
	{
		public const string BasePath = "//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public IWebElement ProcessCheckbox(string option)
		{
			switch (option)
			{
				case "Auto Assign":
					return this.containerElement.FindElement(By.XPath(".//tr[@id='trAutoAssignUser']/td/input"), 2);
				case "Auto Redirect":
					return this.containerElement.FindElement(By.XPath(".//tr[@id='trAutoRedirectChbx']/td/input"), 2);
				default:
					Report.Info("Only Auto Assign and Auto Redirect are valid for Process Products checkboxes! Specified option: " + option);
					return null;
			}
		}

		public bool SelectRegulatorySpecialist(string specialist)
		{
			var el = containerElement.FindElement(By.XPath(".//select[@id='regulatoryusers']"), 2);
			el.Select(specialist);
			return el.SelectedOption() == specialist;
		}

		public bool ClickContinue()
		{
			return containerElement.FindElement(By.XPath(".//span[text()='Continue']"), 2).TryClick();
		}

		public bool ClickCancel()
		{
			return containerElement.FindElement(By.XPath(".//span[text()='Cancel']"), 2).TryClick();
		}

		public bool ClickClose()
		{
			return containerElement.FindElement(By.XPath(".//span[text()='Close']"), 2).TryClick();
		}
	}
}

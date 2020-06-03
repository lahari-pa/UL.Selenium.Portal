using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.SpecFlow.Classes;
using System.Collections.ObjectModel;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Classes;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TableRow = TechTalk.SpecFlow.TableRow;
using OpenQA.Selenium.Interactions;
using UL.Selenium.Portal.WERCSmart.Steps;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioSHAManager : BaseObject
	{
		public const string BasePath = "//div[@id='main']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			try
			{
				StudioUtilites.SwitchToWindow("Wercs Studio");
				this.SwitchToFrame();
				this.containerElement = SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath(BasePath), secondsToWait);
				return this.containerElement != null && base.Wait_for_load(secondsToWait);
			}
			catch
			{
				return false;
			}

		}

		public bool SwitchToFrame()
		{
			try
			{
				SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
				return SeleniumBrowser.SwitchToIFrame("Widget1FRAME") || (SeleniumBrowser.ExitIFrame() && SeleniumBrowser.SwitchToIFrame("Widget1FRAME"));
			}
			catch (Exception ex)
			{
				Report.Error("Failed to switch frame. Exception was thrown: " + ex.Message);
				return false;
			}
		}

		public bool WaitForProductList(int secondsToWait)
		{
			Report.Info("Beginning wait for product list");
			Delay.Seconds(2);
			var tableVisible = this.containerElement.WaitUntilElementVisible(By.XPath("//table[@id='list']"), secondsToWait);
			return tableVisible != null || this.containerElement.FindElements(By.XPath("//table[@id='list']//tr"), 1).Count == 1;
		}

		/// <summary>
		/// Waits for up to 5 seconds for the 'Loading...' div to appear, and then up to the timeout for it to disappear.
		/// </summary>
		public bool Wait_For_Loading_Finish(int timeout = 30)
		{
			try
			{
				Delay.Seconds(15);
				// wait up to 5 seconds for the loading bar to become visible
				SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath("//div[@id='load_list']"), 20);
				// waits up to timeout (30) seconds for the loading bar to then become invisible
				return SeleniumBrowser.WebBrowser.WaitUntilElementInvisible(By.XPath("//div[@id='load_list']"), timeout);
			}
			catch (Exception ex)
			{
				Report.Error("Failed to wait for load to finish. Exception was thrown: " + ex.Message);
				return false;
			}
		}
		public ProductStatus GetproductStatus(string id)
		{
			var thisProductStatus = new ProductStatus();
			Report.Info("Beginning get product status by id: " + id);

			try
			{
				int idIndex = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(
						"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
					.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

				var mySHAManager = new StudioSHAManager();
				mySHAManager.Wait_for_load();
				Product matchingProduct = mySHAManager.GetTopXProducts(1).FirstOrDefault(x => x.ID == id);

				if (matchingProduct == null)
				{
					mySHAManager.ClickBottomMenuOption("search");
					var myProductSearch = new StudioSHAManagerProductSearch();
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

				IWebElement matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (idIndex + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);
				IWebElement matchingSpan = matchingTD.FindElement(By.XPath(".//span"));
				string colour = matchingTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();

				thisProductStatus.CSSColour = colour;
				thisProductStatus.CSSBackgroundColor = matchingSpan.GetCssValue("background-color");
				thisProductStatus.Bold = matchingSpan.GetAttribute("class").ToLower().Contains("bold");
				thisProductStatus.StatusName = matchingSpan.GetAttribute("class")
					.Replace("bold", "", StringComparison.InvariantCultureIgnoreCase).Trim();

			}
			catch (Exception)
			{
				return null;
			}

			return thisProductStatus;
		}

		//idStatus - tPartyForm, hold, elect, brandedcomp, docrequest, batt, kit, rulerunning, rulequeue, ruleerror, feederror,
		public bool WaitForIDToBeStatus(string id, int secondsToWait, string tableStatus, string idStatus,
			bool expectingBold = false, string tableBackground = "none")
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
				ProductStatus thisProductStatus = this.GetproductStatus(id);
				if (thisProductStatus != null)
				{
					if ((idStatus == thisProductStatus.StatusName || idStatus.ToLower() == "n/a") &&
						thisProductStatus.Bold == expectingBold &&
						(tableBackground == "none" || tableBackground == thisProductStatus.CSSBackgroundColor))
					{
						return true;
					}

					string matchReport = "";
					if (idStatus == thisProductStatus.StatusName)
					{
						matchReport += " status matched";
					}
					else
					{
						matchReport += " status did not match. Expecting: " + idStatus + " but got: " +
									   thisProductStatus.StatusName;
					}

					if (thisProductStatus.Bold == expectingBold)
					{
						matchReport += " bolding matched";
					}
					else
					{
						matchReport += " bolding did not match. Expecting: " + expectingBold.ToString() + " but got: " +
									   thisProductStatus.Bold.ToString();
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
			ProductStatus thisProductStatus = this.GetproductStatus(id);
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
			int index = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			for (int i = 0; i < secondsToWait; i++)
			{
				var mySHAManager = new StudioSHAManager();

				if (mySHAManager.GetCurrentStatusFilter() == "Assigned")
				{
					mySHAManager.SelectFromStatusFilter("All");
					var myProductSearch = new StudioSHAManagerProductSearch();
					myProductSearch.Wait_for_load(3);
					myProductSearch.ClickButton("Find");
					mySHAManager.WaitForProductList(30);
				}
				else
				{
					mySHAManager.SelectFromStatusFilter("Assigned");
				}

				Delay.Seconds(5);
				IWebElement matchingTD = SeleniumBrowser.WebBrowser
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

		public string SelectFirstProduct()
		{
			Delay.Seconds(3);
			Report.Info("Attemping to select first product");
			Report.Screenshot();
			IWebElement checkbox = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']//tr//input"))
				.FirstOrDefault(x => x != null);
			Report.Info("Found checkbox");

			//get id no
			IWebElement idTD = checkbox.FindElement(By.XPath("../../td[2]"), 2);
			string id = "";
			if (idTD == null)
			{
				return "";
			}
			else
			{
				id = idTD.GetValue();
			}

			Report.Info("id = " + id);
			if (this.SelectProductByID(id))
			{
				return id;
			}
			else
			{
				return "";
			}
		}

		public string SelectFirstProductWithRetailers()
		{
			Delay.Seconds(3);
			Report.Info("Attemping to select first product with retailers");
			Report.Screenshot();
			IWebElement checkbox = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']//tr//input"))
				.FirstOrDefault(x => x != null);
			Report.Info("Found checkbox");

			//get id no
			IWebElement idTD = checkbox.FindElement(By.XPath("../../td[2]"), 2);
			string id = "";
			if (idTD == null)
			{
				return "";
			}
			else
			{
				id = idTD.GetValue();
			}

			Report.Info("id = " + id);
			if (this.SelectProductByID(id))
			{
				return id;
			}
			else
			{
				return "";
			}
		}

		public bool SelectProductByID(string id)
		{
			try
			{
				Report.Info("Beginning select product by id: " + id);
				Delay.Seconds(5);
				GeneralUtilities.StudioWaitForSpinner(60);
				int index = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(
						"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
					.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

				IWebElement matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);

				if (matchingTD != null)
				{
					Report.Info("Found matching cell");
					matchingTD = SeleniumBrowser.WebBrowser
						.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
						.FirstOrDefault(x => x.GetValue().Trim() == id);
					IWebElement checkbox = matchingTD.FindElement(By.XPath("../td/input"));
					Report.Info("Found checkbox");
					if (checkbox != null)
					{
						if (checkbox.Checked())
						{
							Report.Info("Checkbox is already checked");
							return true;
						}
						int x = 0;
						bool clickedSuccess = false;
						while (x<5 && clickedSuccess==false)
						{
							Delay.Seconds(2);
							checkbox.TryClick();
							if (checkbox.Checked())
							{
								Report.Screenshot();
								clickedSuccess = true;
								return true;
							}
							else
							{
								Report.Info("Attempted to check checkbox but failed.");
									
							}
							x++;

						}
						if (clickedSuccess == false)
						{
							Report.Info("Final attempt to check checkbox failed.");
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
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
			}

			return false;
		}

		public bool RetailerIsInListOfRetailers(string retailerAbbr, string id)
		{
			int indexOfID = SeleniumBrowser.WebBrowser
										.FindElements(By.XPath(
											".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
										.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			int indexOfClients = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			for (int i = 0; i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				if (thisIDTD.GetValue() == id)
				{
					IWebElement thisClientsTD = clientsTDs[i];
					var allClients = thisClientsTD.GetValue().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
					if (allClients.Contains(retailerAbbr))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			return false;

		}

		public bool RetailerIsArchived(string retailerAbbr, string id)
		{
			int indexOfID = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

			int indexOfClients = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			for (int i = 0; i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				if (thisIDTD.GetValue() == id)
				{
					IWebElement thisClientsTD = clientsTDs[i];
					var allClients = thisClientsTD.GetValue().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
					if (allClients.Contains(retailerAbbr + "**"))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			return false;
		}

		public bool RightClickProductByID(string id)
		{
			Delay.Seconds(3);
			Report.Info("Attemping to rightclick product by id: " + id);
			//int index = SeleniumBrowser.WebBrowser
			//	.FindElements(By.XPath(
			//		"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
			//	.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

			//IWebElement matchingTD = SeleniumBrowser.WebBrowser
			//	.FindElements(By.XPath(".//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
			//	.FirstOrDefault(x => x.GetValue().Trim() == id);
			IWebElement matchingTD2 = this.containerElement.FindElement(By.XPath(".//table[@id='list']//tr//td[@aria-describedby='list_Product' and @title = '" + id + "']//span"), 5);
			if (matchingTD2 != null)
			{
				Report.Info("Found matching cell");
				var thisContextMenu = new RightClickProductMenu();
				//matchingTD2.RightClick();
				//This below is to handle the Right click clicking below the element.
				//if this fails in some cases, try the old method first and then check for the context menu (var thisContextMenu = new RightClickProductMenu();) and only if that fails do the new way
				Actions actions = new Actions(SeleniumBrowser.WebBrowser);
				int i = 0;
				while (i<70)
				{
					Delay.Seconds(2);
					actions.MoveToElement(matchingTD2);
					actions.MoveByOffset(0, i);
					actions.ContextClick();
					actions.Perform();
					if (thisContextMenu.MenuExists())
					{
						return true;
					}
					i = i - 10;
				}				
				return false;
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
				var ListOfProductRows = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='list']//tr"), 3)
					.ToList();
				if (ListOfProductRows == null || ListOfProductRows.Count == 1)
				{
					//count of 1 row means only headers so table is empty
					return true;
				}
			}
			catch (Exception)
			{
				return true;
			}

			return false;
		}

		public int GetProductCount()
		{
			IWebElement pageCount = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[@id='listPager_right']/div"), 2);
			if (pageCount == null)
			{
				Report.Info("No page count has been found");
				return -1;
			}

			string pattern = @"of\s\d+";
			var regex = new Regex(pattern);
			Match match = regex.Match(pageCount.GetValue());
			if (match.Success)
			{
				return Convert.ToInt16(match.Value.Replace("of ", ""));
			}
			else
			{
				Report.Info("No matching pattern has been found");
			}

			return -1;
		}

		public List<Product> GetTopXProducts(int topX)
		{
			Delay.Seconds(1);
			Report.Info("Getting top " + topX.ToString() + " products");
			List<IWebElement> ListOfProductRows = null;

			if (this.ProductTableIsEmpty())
			{
				return new List<Product>();
			}

			ListOfProductRows = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']/tbody//tr[@class!='jqgfirstrow']"), 3).ToList();

			Report.Info("Got product rows: " + ListOfProductRows.Count.ToString());

			if (topX > ListOfProductRows.Count)
			{
				topX = ListOfProductRows.Count;
			}

			var ListOfHeaders = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList();

			for (int index = 1; index < ListOfHeaders.Count; index++)
			{
				bool nullOrEmpty = string.IsNullOrEmpty(ListOfHeaders[index]);
				if (nullOrEmpty)
				{
					ListOfHeaders[index] = "Distributor";
				}
			}

			Report.Info("Got list of headers");
			Report.Info($"The list of headers found was a follow: {string.Join(",", ListOfHeaders)}");
			var ListOfProducts = new List<Product>();
			//get all columns
			ListOfProductRows = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']/tbody//tr[@class!='jqgfirstrow']"), 3).ToList();
			for (int j = 0; j < Math.Min(ListOfProductRows.Count, topX + 1); j++)
			{
				var rowValues = new List<string>();
				try
				{
					var rowColumns = ListOfProductRows[j]?.FindElements(By.XPath(".//td"), 2)?.ToList();
					if (rowColumns != null)
					{
						if (rowColumns.Any())
						{
							rowValues = rowColumns.Select(x => x.GetValue()).ToList();
						}
						else
						{
							Report.Failure("Failed to get row " + j);
							continue;
						}
					}
					else
					{
						Report.Failure("Failed to get row " + j);
						continue;
					}
				}
				catch (Exception e)
				{
					Report.Failure("Failed to get row " + j + ". Exception message: " + e.Message);
					continue;
				}
				var thisProduct = new Product();
				int addIndex = 1;
				for (int i = 0; i < ListOfHeaders.Count(); i++)
				{
					//Report.Info("Looking at column: " + ListOfHeaders[i]);
					switch (ListOfHeaders[i])
					{
						case "Product":
							string pValue = rowValues[i];
							if (pValue.Trim().Length != 0)
							{
								thisProduct.ID = pValue.Trim();
							}

							break;
						case "Name":
							string pName = rowValues[i];
							if (pName.Trim().Length != 0)
							{
								thisProduct.Name = pName;
							}

							break;
						case "Distributor":
							thisProduct.Distributor = rowValues[i];
							break;
						case "Supplier":
							thisProduct.Supplier = rowValues[i];
							break;
						case "User":
							thisProduct.User = rowValues[i].Trim();
							break;
						case "Status":
							thisProduct.Status = rowValues[i].Trim();
							Report.Info("Status is: " + thisProduct.Status);
							try
							{
								IWebElement status = SeleniumBrowser.WebBrowser.FindElement(
									By.XPath("//table[@id='list']//tr[@class!='jqgfirstrow'][" + (j + 1) + "]//td[" +
											 (i + addIndex) + "]"), 2);
								if (status != null)
								{
									thisProduct.ColourRGB = status.GetCssValue("Color");
								}

							}
							catch (Exception e)
							{
								Report.Info("There was a problem with getting status colour: " + e.Message);
							}
							Report.Info($"Finished looking at status");
							break;
						case "Original Submission":
							Report.Info($"Starting on: Original Submission");
							string pOS = rowValues[i].Trim();
							if (pOS.Length > 0)
							{
								thisProduct.OriginalSubmission = Convert.ToDateTime(pOS);
							}

							break;
						case "Current Submission":
							Report.Info($"Starting on: Current Submission");
							string pCS = rowValues[i].Trim();
							if (pCS.Length > 0)
							{
								thisProduct.CurrentSubmission = Convert.ToDateTime(pCS);
							}

							break;
						case "Last ActivityDate":
							Report.Info($"Starting on: Last ActivityDate");
							string pAD = rowValues[i].Trim();
							if (pAD.Length > 0)
							{
								thisProduct.LastActivityDate = Convert.ToDateTime(pAD);
							}

							break;
						case "Due Date":
							Report.Info($"Starting on: Due Date");
							string pDD = rowValues[i].Trim();
							if (pDD.Length > 0)
							{
								thisProduct.DueDate = Convert.ToDateTime(pDD);
							}

							break;
						case "Reviewer":
							Report.Info($"Starting on: Reviewer");
							Report.Info($"value of I was: {i}");
							Report.Info($"Row Value at I was: {rowValues[i]}");
							thisProduct.Reviewer = rowValues[i].Trim();
							break;
						case "SDS":
							Report.Info($"Starting on: SDS");
							thisProduct.SDS = rowValues[i].Trim() == "Yes";
							break;
						case "Canada SDS":
							Report.Info($"Starting on: Canada SDS");
							thisProduct.CanadaSDS = rowValues[i].Trim() == "Yes";
							break;
						case "Clients":
							Report.Info($"Starting on: Clients");
							thisProduct.Clients = rowValues[i].Trim();
							break;
						case "T. Reg":
							Report.Info($"Starting on: T. Reg");
							thisProduct.TReg = rowValues[i].Trim() == "Yes";
							break;
						case "Last Pub Date":
							Report.Info($"Starting on: Last Pub Date");
							thisProduct.LastPubDate = rowValues[i].Trim();
							break;
						case "GHS":
							Report.Info($"Starting on: GHS");
							Report.Info($"value of I was: {i}");
							Report.Info($"Row Values is a list of strings containing the following values: {string.Join(",", rowValues)}");
							Report.Info($"Row Value at I was: {rowValues[i]}");
							thisProduct.GHS = rowValues[i].Trim();
							Report.Info($"Row value added for GHS");
							break;
						case "Refeed":
							Report.Info($"Starting on: Refeed");
							thisProduct.Refeed = rowValues[i].Trim() == "Yes";
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

		public List<string> GetAllProductIds()
		{
			return this.containerElement.FindElements(By.XPath(".//table[@id='list']/tbody//tr/td/span[@class]"), 2).Select(x => x.Text).ToList();
		}
		public bool ProductWithIDHasRedBorders(string id)
		{
			Delay.Seconds(3);
			Report.Info("Attemping to select product by id: " + id);
			int index = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");

			IWebElement matchingTD = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
				.FirstOrDefault(x => x.GetValue().Trim() == id);

			if (matchingTD != null)
			{
				Report.Info("Found matching cell");
				matchingTD = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath("//table[@id='list']//tr//td[" + (index + 1).ToString() + "]"))
					.FirstOrDefault(x => x.GetValue().Trim() == id);

				string bottomBorderColour = matchingTD.GetCssValue("border-bottom-color");
				Report.Info("Bottom border colour: " + bottomBorderColour);
				string leftBorderColour = matchingTD.GetCssValue("border-left-color");
				string rightBorderColour = matchingTD.GetCssValue("border-right-color");

				if (bottomBorderColour == "rgba(205, 10, 10, 1)" && leftBorderColour == "rgba(205, 10, 10, 1)" &&
					rightBorderColour == "rgba(205, 10, 10, 1)")
				{
					return true;
				}

			}
			else
			{
				Report.Error("Could not find matching cell for product with id: " + id);
			}

			return false;
		}

		public bool TopRowProductsTableMatchesId(string id)
		{
			// JS. possible null exception - GetTopXProducts() can return a list with 0 items
			//return GetTopXProducts(1).FirstOrDefault().ID == id;
			List<Product> products = this.GetTopXProducts(1);
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
				Delay.Seconds(1);
				IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkProcess']"));
				return button.TryClick();
			}
			catch (Exception)
			{
				Report.Error("process product data button was not found");
				return false;
			}

		}

		public bool ClickReports()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkReports']"));
			return button.TryClick();
		}

		public bool ClickExport()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkExport']"));
			return button.TryClick();
		}

		public bool ClickDataCodeExport()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkDataCodeExport']"));
			return button.TryClick();
		}

		public bool ClickAutoAssign()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkAutoAssign']"));
			return button.TryClick();
		}

		public bool ClickAddToRecertification()
		{
			IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkAddToRecertify']"));
			return button.TryClick();
		}

		public bool SetAutoAssignRegulatorySpecialisttoProduct(bool set)
		{
			IWebElement enterField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='chkAutoAssignUser']"));
			enterField.Check(set);
			return enterField.Checked() == set;
		}

		public bool SelectRegulatorySpecialist(string name)
		{
			IWebElement select = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='regulatoryusers']"));
			select.Select(name);
			return (select.SelectedOption() == name);
		}

		public bool SetAutoRedirectToClientsIfConditionMatch(bool set)
		{
			IWebElement enterField = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='chkAutoRedirect']"));
			enterField.Check(set);
			return enterField.Checked() == set;
		}

		public bool ClickContinueInProcessProducts()
		{
			ReadOnlyCollection<IWebElement> buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-product']/..//button"));
			IWebElement continueButton =
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
				IWebElement processedList =
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@id='dialog-product']//div[@id='message']"));
				ReadOnlyCollection<IWebElement> products = processedList.FindElements(By.XPath(".//span"));
				IWebElement matchingProduct = products.FirstOrDefault(x => x.GetValue().Trim().Contains(id));
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
			ReadOnlyCollection<IWebElement> buttons = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-product']/..//button"));
			IWebElement closeButton =
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
				ReadOnlyCollection<IWebElement> ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='ddtopmenubar']/ul/li/a"));
				IWebElement menuOption = ListOfTopMenuOptions.FirstOrDefault(x => x.Text.ToLower() == option.ToLower());
				return menuOption.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickSuppliersButton()
		{
			try
			{
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					SeleniumBrowser.ExitIFrame();
					if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
					{
						Report.Info("Could not switch to iframe");
						return false;
					}
				}

				IWebElement SupplierLink =
					SeleniumBrowser.WebBrowser.FindElement(
						By.XPath(".//div[@id='ddtopmenubar']//li[@id='supplierbar']/a"));

				return SupplierLink.TryClick();
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return false;
			}

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
						Report.Info("Could not switch to iframe");
						return false;
					}
				}

				ReadOnlyCollection<IWebElement> ListOfTopMenuOptions =
					SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//ul[@id='ddsubmenu1']/li/a"));
				IWebElement menuOption =
					ListOfTopMenuOptions.FirstOrDefault(x => x.GetValue(true).ToLower() == option.ToLower());
				Report.Info("Found options: " +
							string.Join(",", ListOfTopMenuOptions.Select(x => x.GetValue(true)).ToList()));
				if (menuOption != null)
				{
					return menuOption.TryClick(ClickExtensions.ClickType.JavaScript);
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
			IWebElement statusSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='status']"));
			return statusSelect.SelectedOption();
		}

		public bool SelectFromStatusFilter(string option)
		{
			//Report.Info("Beinnign select from status filter: " + option);
			try
			{
				IWebElement statusSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='status']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
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

			ReadOnlyCollection<IWebElement> listOfOptions = SeleniumBrowser.WebBrowser.FindElements(By.XPath(
				"//table[contains(@class,'navtable')]//td[not(contains(@class, 'disabled')) and not(contains(@style, 'none'))]/div"));
			IWebElement matchingOption = listOfOptions.FirstOrDefault(x => x.GetValue().ToLower().Contains(option.ToLower()));

			if (matchingOption == null)
			{
				Report.Info("No matching menu option found: " + option + ". Available options: " +
							string.Join(",", listOfOptions));
				return false;
			}

			return matchingOption.TryClick();
		}


		public List<SHAManagerProdcutUPC> GetUPCs()
		{
			var rList = new List<SHAManagerProdcutUPC>();
			IList<IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[@class='DarkBack']//following-sibling::tr"), 2);
			IWebElement headerRow = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//tr[@class='DarkBack']"), 2);
			if (headerRow == null)
			{
				Report.Info("Could not locate 'dark black' header row");
				return null;
			}

			IList<IWebElement> headers = headerRow.FindElements(By.XPath("./td"), 2);
			int upcPosition = headers.IndexOf(headerRow.FindElement(By.XPath(".//th[contains(text(),'UPC Number')]"))) +
							  1;

			foreach (IWebElement row in rows)
			{
				var upcText = row.Text.Split(' ')[0];
				Report.Info("UPC row text: " + upcText);
				var thisUpc = new SHAManagerProdcutUPC {

					UPCNumber = upcText
				};

				rList.Add(thisUpc);
			}

			Report.Info($"Found {rList.Count} UPCs");
			return rList;
		}

		public bool ClickCaseUPCSavedAsInProducUPCTable(string savedAs)
		{
			if (!Context.Contains(savedAs))
			{
				Report.Failure($"The UPC saved as: {savedAs} could not be found in context");
				return false;
			}
			var expectedUPCNum = Context.GetFromContext(savedAs).ToString();
			IList<IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[not(@class='DarkBack')]"), 2);
			foreach (var item in rows)
			{
				IWebElement linkBox = item.FindElement(By.XPath(".//a"), 2);

				if (linkBox.Text.Contains(expectedUPCNum + "*"))
				{
					return linkBox.TryClick();
				}
			}
			Report.Failure("Could not Find UPC Link for the Case UPC: " + expectedUPCNum);
			return false;
		}
		public bool ClickUPCSavedAsInProducUPCTable(string savedAs)
		{
			var expectedUPCNum = (string)Context.GetFromContext(savedAs);
			IList<IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[not(@class='DarkBack')]"), 2);
			foreach (var item in rows)
			{
				IWebElement linkBox = item.FindElement(By.XPath(".//a"), 2);

				if (linkBox.Text.Contains(expectedUPCNum))
				{
					return linkBox.TryClick();
				}
			}
			Report.Failure("Could not Find UPC Link for the UPC: " + expectedUPCNum);
			return false;
		}

		public bool ConfirmRetailerExistsForUPC(string retailer, string upc)
		{
			IWebElement headerRow = SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath(".//tr[@class='DarkBack']"), 10);
			if (headerRow == null)
			{
				Report.Error("Could not locate 'dark black' header row");
				return false;
			}
			IList<IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[not(@class='DarkBack')]"), 2);
			if (!rows.Any())
			{
				Report.Failure("No UPC rows were found!");
				return false;
			}
			IWebElement upcRow = null;
			foreach (IWebElement row in rows)
			{
				string upcNumber = row.Text.Split(' ')[0];
				if (upcNumber.Contains(upc))
				{
					upcRow = row;
				}
			}
			if (upcRow == null)
			{
				Report.Info("Failed to find UPC " + upc + " in row!");
				return false;
			}
			IWebElement retElement = upcRow.FindElement(By.XPath(@".//td[@title=""" + retailer + @"""]"), 2);
			if (retElement == null)
			{
				Report.Info("Could not find retailer column");
			}
			return retElement != null && !retElement.Text.IsNullOrEmpty();
		}

		public bool ConfirmUPCArchived(string upc)
		{
			IList<IWebElement> rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//tr[not(@class='DarkBack')]"), 2);
			IWebElement upcRow = null;
			foreach (IWebElement row in rows)
			{
				string upcNumber = row.Text.Split(' ')[0];
				if (upcNumber == upc)
				{
					upcRow = row;
				}
			}

			if (upcRow == null)
			{
				Report.Info("Failed to find UPC " + upc + " in row!");
				return false;
			}

			string background = upcRow.GetCssValue("background-color");

			Report.Info($"The css value was found to be: {background}");
			string backgroundColourTest = upcRow.GetAttribute("background-color");
			Report.Info($"The string for the attribute 'background-color' was found to be: {backgroundColourTest}");

			return background == "rgb(235, 235, 224)";
		}

		public bool ClickProcessRecertification()
		{
			try
			{
				IWebElement button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='lnkRecertification']"));
				return button.TryClick();
			}
			catch (Exception)
			{
				Report.Error("process recertification button was not found");
				return false;
			}

		}

		public string ReturnIDOfProductWhichIsBlueAndHasClients()
		{
			int indexOfID = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			int indexOfClients = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			for (int i = 0; i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				IWebElement thisClientsTD = clientsTDs[i];
				string colour = thisIDTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();
				if (colour == "rgba(0, 0, 255, 1)" && thisClientsTD.GetValue().Length > 0)
				{
					string bottomBorderColour = thisIDTD.GetCssValue("border-bottom-color");
					string leftBorderColour = thisIDTD.GetCssValue("border-left-color");
					string rightBorderColour = thisIDTD.GetCssValue("border-right-color");

					if (!(bottomBorderColour == "rgba(205, 10, 10, 1)" && leftBorderColour == "rgba(205, 10, 10, 1)" &&
						  rightBorderColour == "rgba(205, 10, 10, 1)"))
					{
						return thisIDTD.GetValue().Trim();
					}

				}
			}

			return null;

		}

		public ProductInformation ReturnProductInformationOfProductwithIsBlueAndHasClients()
		{
			int indexOfID = SeleniumBrowser.WebBrowser
							.FindElements(By.XPath(
								".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
							.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			int indexOfName = SeleniumBrowser.WebBrowser
										.FindElements(By.XPath(
											".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
										.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Name");
			int indexOfClients = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> nameTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfName + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			// start at a random place in the list. This solves the problem where we are always selecting the first product in the list,
			// which then accumulates too many Retailers.
			Random rnd = new Random();
			for (int i = rnd.Next(idTDs.Count); i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				IWebElement thisNameTD = nameTDs[i];
				IWebElement thisClientsTD = clientsTDs[i];
				string colour = thisIDTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();
				if (colour == "rgba(0, 0, 255, 1)" && thisClientsTD.GetValue().Length > 0)
				{
					string bottomBorderColour = thisIDTD.GetCssValue("border-bottom-color");
					string leftBorderColour = thisIDTD.GetCssValue("border-left-color");
					string rightBorderColour = thisIDTD.GetCssValue("border-right-color");

					if (!(bottomBorderColour == "rgba(205, 10, 10, 1)" && leftBorderColour == "rgba(205, 10, 10, 1)" &&
						  rightBorderColour == "rgba(205, 10, 10, 1)"))
					{
						return new ProductInformation {
							Id = thisIDTD.GetValue().Trim(),
							Name = thisNameTD.GetValue().Trim()
						};
					}

				}
			}

			return null;
		}

		public ProductInformation ReturnProductInformationOfProductwithIsBlueAndHasClientsAndUPC()
		{
			int indexOfID = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			int indexOfName = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Name");
			int indexOfClients = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]")).Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> nameTDs = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfName + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			// start at a random place in the list. This solves the problem where we are always selecting the first product in the list,
			// which then accumulates too many Retailers.
			Random rnd = new Random();
			for (int i = rnd.Next(idTDs.Count); i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				IWebElement thisNameTD = nameTDs[i];
				IWebElement thisClientsTD = clientsTDs[i];
				string colour = thisIDTD.FindElement(By.XPath(".//span")).GetCssValue("color").ToString();
				if (colour == "rgba(0, 0, 255, 1)" && thisClientsTD.GetValue().Length > 0)
				{
					string bottomBorderColour = thisIDTD.GetCssValue("border-bottom-color");
					string leftBorderColour = thisIDTD.GetCssValue("border-left-color");
					string rightBorderColour = thisIDTD.GetCssValue("border-right-color");

					if (!(bottomBorderColour == "rgba(205, 10, 10, 1)" && leftBorderColour == "rgba(205, 10, 10, 1)" &&
						  rightBorderColour == "rgba(205, 10, 10, 1)"))
					{
						var shaSteps = new Steps_SHA();
						string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
						string idString = thisIDTD.Text;
						this.RightClickProductByID(idString);
						Context.AddToContext("MainSHAindowHandle", currentHandle);
						Report.StartStep("I click 'UPC Retailer and Feed'");
						shaSteps.GivenInTheSHAManagerGridWhenTheRightClickContextMenuIsOpenISelectOption("UPC Retailer and Feed");
						Delay.Seconds(5);
						SeleniumBrowser.WebBrowser.SwitchTo().Window(currentHandle);
						var studioSHAManger = new StudioSHAManager();

						Delay.Seconds(10);
						shaSteps.SwitchToProductListUpcWindow();
						Delay.Seconds(4);
						string url2 = SeleniumBrowser.WebBrowser.Url;
						List<SHAManagerProdcutUPC> displayedUpcs = new StudioSHAManager().GetUPCs();
						Report.Info($"The number of UPCs displayed in the UPC Details page is: {displayedUpcs.Count}");
						if (displayedUpcs.Count > 0)
						{


							new GlobalSteps().SaveTheCurrentWindowAs("CurrentWindow");
							string productsGridHandle = (string)Context.GetFromContext("MainWindowHandle");
							SeleniumBrowser.WebBrowser.SwitchTo().Window(productsGridHandle);
							Delay.Seconds(5);
							SeleniumBrowser.SwitchToIFrame("Widget1FRAME");						
							string newTab = (string)Context.GetFromContext("CurrentWindow");
							SeleniumBrowser.WebBrowser.SwitchTo().Window(newTab);
							new GlobalSteps().SwitchBackToMainWindow("CurrentWindow");
							SeleniumBrowser.WebBrowser.SwitchTo().Window(productsGridHandle);
							SeleniumBrowser.SwitchToIFrame("Widget1FRAME");
							return new ProductInformation
							{
								Id = thisIDTD.GetValue().Trim(),
								Name = thisNameTD.GetValue().Trim()
							};
						}
						new GlobalSteps().SaveTheCurrentWindowAs("CurrentWindow");
						string failedproductsGridHandle = (string)Context.GetFromContext("MainWindowHandle");
						SeleniumBrowser.WebBrowser.SwitchTo().Window(failedproductsGridHandle);
						Delay.Seconds(5);
						SeleniumBrowser.SwitchToIFrame("Widget1FRAME");
						string failednewTab = (string)Context.GetFromContext("CurrentWindow");
						SeleniumBrowser.WebBrowser.SwitchTo().Window(failednewTab);
						new GlobalSteps().SwitchBackToMainWindow("CurrentWindow");
						SeleniumBrowser.WebBrowser.SwitchTo().Window(failedproductsGridHandle);
						SeleniumBrowser.SwitchToIFrame("Widget1FRAME");

					}

				}
			}

			return null;
		}

		public List<string> ReturnClientsOfProductByID(string id)
		{
			int indexOfID = SeleniumBrowser.WebBrowser
							.FindElements(By.XPath(
								".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
							.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Product");
			int indexOfClients = SeleniumBrowser.WebBrowser
				.FindElements(By.XPath(
					".//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
				.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

			ReadOnlyCollection<IWebElement> idTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfID + 1).ToString() + "]"));

			ReadOnlyCollection<IWebElement> clientsTDs = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath(".//table[@id='list']//tr[not(@class='jqgfirstrow')]//td[" + (indexOfClients + 1).ToString() + "]"));

			for (int i = 0; i < idTDs.Count; i++)
			{
				IWebElement thisIDTD = idTDs[i];
				IWebElement thisClientsTD = clientsTDs[i];
				if (thisIDTD.GetValue().Trim() == id)
				{
					return thisClientsTD.GetValue().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
				}
			}
			return null;
		}

		public bool ConfirmThereIsOneProductInTheGrid()
		{
			IList<IWebElement> rows = this.containerElement.FindElements(By.XPath("//table[@id='list']//tbody//tr[not(@class='jqgfirstrow')]"));
			return rows.Count == 1;
		}

		public string GetProductStatusByRetailer(string retailer)
		{

			string retailerStatus = "";
			string retailerAbbr = "";
			if (Context.GetFromContextRegex(retailer, out var result))
			{
				Report.Info("Getting retailer from context: " + retailer);
				retailer = result.ToString();
			}
			Report.Info("Beginning get product status by retailer: " + retailer);

			var abbr = new RetailerAbbreviations();
			if (!abbr.Map.TryGetValue(retailer, out retailerAbbr))
			{
				Report.Error("Failed to get retailer abbreviation for full name: " + retailer);
				return null;
			}
			Report.Info("Search for Retailer with Initials: " + retailerAbbr);
			try
			{
				int retailerIndex = SeleniumBrowser.WebBrowser
					.FindElements(By.XPath(
						"//div[@id='gview_list']//table/thead/tr[contains(@class, 'labels') and @role='rowheader']/th[not(contains(@style, 'none'))]"))
					.Select(x => x.GetValue().Trim()).ToList().FindIndex(a => a == "Clients");

				var mySHAManager = new StudioSHAManager();
				mySHAManager.Wait_for_load();
				Product matchingProduct = mySHAManager.GetTopXProducts(2).FirstOrDefault(x => x.Clients == retailerAbbr);
				Report.Info("The Retailer initials found are: " + matchingProduct.Clients);
				Report.Info("A Status was found for the Product. The Status is: " + matchingProduct.Status);
				retailerStatus = matchingProduct.Status;

				if (matchingProduct == null)
				{
					Report.Failure("Could not find a Product with retailer: " + retailerAbbr + ".");
					return null;
				}

			}
			catch (Exception ex)
			{
				Report.Error(ex.Message);
				return null;
			}

			return retailerStatus;
		}
		public bool ClickMessageCenter()
		{
			try
			{
				if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
				{
					SeleniumBrowser.ExitIFrame();
					if (!SeleniumBrowser.SwitchToIFrame("Widget1FRAME"))
					{
						Report.Info("Could not switch to iframe");
						return false;
					}
				}

				IWebElement messageCenter =
					SeleniumBrowser.WebBrowser.FindElement(
						By.XPath(".//div[@id='ddtopmenubar']//li//a[contains(text(), 'MessageCenter')]"), 2);

				return messageCenter.TryClick();
			}
			catch (Exception e)
			{
				Report.Info(e.Message);
				return false;
			}

		}

		public List<string> FindColumnInUPCRetailerAndFeedPageWithTable(Table table)
		{
			List<string> columnsNotFound = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				IWebElement columnName = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//th[contains(text(),'" + row["Column Name"] + "')]"), 2);
			
				if (columnName == null)
				{
					columnsNotFound.Add(row["Column Name"]);
				}
			}

			return columnsNotFound;

		}

		public bool ConfirmUInSecondColumn(string productID)
		{
			IWebElement secondColumnU = this.containerElement.FindElement(By.XPath(".//td[@role='gridcell']//span[text()='" + productID + "']/../following-sibling::td[@title='UPC Update Only']"), 2);

			if (secondColumnU != null)
			{
				return true;
			}

			return false;
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
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchstatus']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectFromStatusFilter(string option)
		{
			try
			{
				Report.Info("Beginning select from status filter");
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchstatus']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectFromClientFilter(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchclient']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectFromSearchPatternFilter(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='drpSearchPattern']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool SelectFromDateRangeFilter(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='ddFilterByDateType']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool SelectFromTRegFilter(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='ddTReg']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool EnterProductID(string iD)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchProduct']"));
			enterField.EnterText(iD);
			return (enterField.GetValue() == iD);
		}

		public bool EnterProductName(string name)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchName']"));
			enterField.EnterText(name);
			return (enterField.GetValue() == name);
		}

		//format - mm/dd/yy
		public bool EnterLastActivityDate(string date)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtLastDate']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterDateFrom(string date)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='fromDatepicker']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterDateTo(string date)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='toDatepicker']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterSubmissionDate(string date)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchDate']"));
			enterField.EnterText(date);
			return (enterField.GetValue() == date);
		}

		public bool EnterSupplier(string supplier)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchSupplier']"));
			enterField.EnterText(supplier);
			return (enterField.GetValue() == supplier);
		}

		public bool EnterUPC(string upc)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchUPC']"));
			enterField.EnterText(upc);
			return (enterField.GetValue() == upc);
		}

		public bool EnterParentUPC(string upc)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchPUPC']"));
			enterField.EnterText(upc);
			return (enterField.GetValue() == upc);
		}

		public bool EnterUser(string user)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchUser']"));
			enterField.EnterText(user);
			return (enterField.GetValue() == user);
		}

		public bool EnterReviewer(string user)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchReviewer']"));
			enterField.EnterText(user);
			return (enterField.GetValue() == user);
		}

		public bool EnterOrderNo(string orderNo)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtSearchOrder']"));
			enterField.EnterText(orderNo);
			return (enterField.GetValue() == orderNo);
		}

		public bool CheckOnSuspended(bool check)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='chkOnHold']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckRecertificationActive(bool check)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='chkIsRecertActive']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckGoodGuideOnlyProducts(bool check)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='chkGGOnly']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool CheckECommFlowProducts(bool check)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='chkeCommProduct']"));
			enterField.Check(check);
			return enterField.Checked() == check;
		}

		public bool SelectFromRecommendedUseFilter(string option)
		{
			try
			{
				IWebElement recUseSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchru']"));
				recUseSelect.Select(option);
				return recUseSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool SelectFromFlashPointRangeFilter(string option)
		{
			try
			{
				IWebElement flashPtSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchfp']"));
				flashPtSelect.Select(option);
				return flashPtSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool SelectFromPHRangeFilter(string option)
		{
			try
			{
				IWebElement phSelect = this.containerElement.FindElement(By.XPath(".//select[@id='searchph']"));
				phSelect.Select(option);
				return phSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}

		}
		public bool EnterUNNumber(string unNumber)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//input[@id='txtUNNumber']"));
			enterField.EnterText(unNumber);
			return (enterField.GetValue() == unNumber);
		}

		public bool ClickButton(string button)
		{
			ReadOnlyCollection<IWebElement> buttonList = this.containerElement.FindElements(By.XPath(".//button/span"));
			IWebElement matchingButton = buttonList.FirstOrDefault(x => x.GetValue().Trim() == button);
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

	class StudioSHAManagerArchivedProduct : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[contains(@aria-labelledby,'IsArchiveProduct')]");

		

		public bool ArchivedUPCPopupTitle(string title, out string displayedTitle) =>
			title == (displayedTitle = this.containerElement.FindElement(By.Id("ui-dialog-title-dialog-IsArchiveProduct")).GetInnerText());


		public bool VerifyPopupContents(string uPC, out string failedAt)
		{
			failedAt = string.Empty;
			IWebElement content = this.FindElement(By.XPath("//div[@id='archivedProductId']"));
			IWebElement firstLine = content.FindElement(By.XPath("..//p"));
			ReadOnlyCollection<IWebElement> contents = content.FindElements(By.XPath("..//p//p"));
			ReadOnlyCollection<IWebElement> clients = content.FindElements(By.XPath("..//li"));

			var listContent = new List<string>();

			string firstLineString = firstLine.GetInnerText().Split('\r')[0];

			listContent.Add(firstLineString);

			foreach (IWebElement item in contents)
			{
				listContent.Add(item.GetInnerText());
			}

			var clientContent = new List<string>();
			foreach (IWebElement client in clients)
			{
				clientContent.Add(client.GetInnerText());
			}

			if (!Regex.IsMatch(listContent[0], "Product .+ is Archived."))
			{
				failedAt += " Product is Archived. ";
			}

			if (!Regex.IsMatch(listContent[1], "Archived date .+"))
			{
				failedAt += " Archived date. ";
			}

			if (!Regex.IsMatch(listContent[2], "Archived by .+"))
			{
				failedAt += " Archived by. ";
			}

			return failedAt.Length == 0;
		}

		internal bool ClosePopup() =>
			this.containerElement.FindElement(By.XPath("//*[@aria-labelledby='ui-dialog-title-dialog-IsArchiveProduct']//span[@class='ui-button-text']")).TryClick();
	}

	class ProcessProducts : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-status-update']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public List<string> GetAllRetailers()
		{
			string retailerSpan = this.containerElement.FindElement(By.XPath(".//input[@id='clients']/..")).GetInnerHTML();
			string regexSplitPattern = @"\<input\stype.*?value=.*?\>";

			var Retailers = Regex.Split(retailerSpan, regexSplitPattern)
				.Select(x => Regex.Replace(x, regexSplitPattern, "").Replace("<br>", "").Trim()).ToList();

			return Retailers;
		}

		public bool SelectRetailer(string retailerName)
		{
			Report.Info("Beginning select retailer: " + retailerName);
			string retailerSpan = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='clients']/..")).GetInnerHTML();
			var splitOnBr = Regex.Split(retailerSpan, @"\<br\>").ToList();
			string matchingInputString = splitOnBr.FirstOrDefault(x => x.Contains(retailerName));

			string regexSplitPattern = @"value=(.*)\>";
			var regex = new Regex(regexSplitPattern);
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
					IWebElement matchInput = this.containerElement.FindElement(By.XPath(".//input[@value='" + validID + "']"));
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
				IWebElement statusDD = this.containerElement.FindElement(By.XPath(".//select[@id='statusupdate']"));
				statusDD.Select(status);
				return statusDD.SelectedOption() == status;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool ClickUpdateStatus()
		{
			try
			{
				IWebElement updateStatusButton = this.containerElement.FindElement(By.XPath(".//select[@id='statusupdate']/following-sibling::a"));
				return updateStatusButton.TryClick();
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool ClickRefeedToClient()
		{
			try
			{
				IWebElement refeedToClient = this.containerElement.FindElement(By.XPath(".//fieldset[@id='fldFeedClient']/a"));
				return refeedToClient.TryClick();
			}
			catch (Exception)
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
			return this.containerElement.Displayed;
		}

		public List<string> GetAllOptions()
		{
			return this.containerElement.FindElements(By.XPath(".//li[not(contains(@style, 'none'))]")).Select(x => x.GetValue()).ToList();
		}

		public bool SelectOption(string selectOption)
		{
			ReadOnlyCollection<IWebElement> listOfOptions = this.containerElement.FindElements(By.XPath(".//li[not(contains(@style, 'none'))]"));
			IWebElement matchingOption = listOfOptions.FirstOrDefault(x => x.GetValue().Contains(selectOption));
			if (matchingOption == null)
			{
				List<string> Options = this.GetAllOptions();
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
				catch (Exception)
				{
					//do nothing
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool PopupExists()
		{
			return this.containerElement.Displayed;
		}

		public bool SetAutoAssignRegulatorySpecialistToProduct(bool setChecked)
		{
			IWebElement checkBox =
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
			ReadOnlyCollection<IWebElement> buttons =
				SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-recertification']/..//button"));

			IWebElement matchingButton =
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
			ReadOnlyCollection<IWebElement> buttons =
				SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='dialog-recertification']/..//button"));
			IWebElement matchingButton =
				buttons.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetValue().Contains(buttonName));

			if (matchingButton == null)
			{
				Report.Info("Could not find button: " + buttonName);
				return false;
			}

			if (!matchingButton.Displayed)
			{
				Report.Info("Button found but not visible");
				return false;
			}
			return true;
		}

		public bool SelectRegulatorySpecialist(string specialistName)
		{
			IWebElement selectSpecialist =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//div[@id='dialog-recertification']//select[@id='regUsers']"), 2);

			if (selectSpecialist == null)
			{
				Report.Info("Select box was not found");
				return false;
			}

			IList<IWebElement> ListOfSpecialists = SeleniumBrowser.WebBrowser.FindElements(
				By.XPath("//div[@id='dialog-recertification']//select[@id='regUsers']/option"), 2);

			IWebElement matchingItem = ListOfSpecialists.FirstOrDefault(x => x.GetValue().Contains(specialistName));

			if (matchingItem == null)
			{
				Report.Info("Specialist: " + specialistName + " was not found in the list", "Found specialist");
				return false;
			}

			return matchingItem.TryClick();
		}

		public bool WaitForProcessing(int secondsToWait)
		{
			Report.Info("Wait for processing...");
			string progress = "0";
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					IWebElement progressBar =
						SeleniumBrowser.WebBrowser.FindElement(
							By.XPath("//div[@id='dialog-recertification']//div[@id='progBarRecertification']"), 2);

					if (progressBar != null)
					{
						progress = progressBar.GetProperty("aria-valuenow");
						Report.Info("Progress: " + progress);

						if (progress == "100")
						{
							return true;
						}
						else
						{
							Report.Info("Progress is: " + progress);
						}
					}

				}
				catch (Exception)
				{
					Report.Info("Exception");
				}
				IWebElement processMessage = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@id='msgRecertification']//span"), 2);
				if (processMessage != null)
				{
					if (processMessage.GetValue().Contains("Processed Recertification"))
					{
						Report.Info(processMessage.GetValue());
						Report.Screenshot();
						return true;
					}
				}

				Delay.Seconds(1);
			}

			return false;

		}

		public List<string> GetProcessingMessages()
		{
			IWebElement progressMessage =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//div[@id='dialog-recertification']//span[@id='msgRecertification']"), 2);

			if (progressMessage == null)
			{
				Report.Info("Progress message was not found");
				return new List<string>();
			}

			ReadOnlyCollection<IWebElement> progressMessages = progressMessage.FindElements(By.XPath("./span"));
			if (progressMessages.Count == 0)
			{
				Report.Info("Progress messages not found");
				return new List<string>();
			}

			return progressMessages.Select(x => x.GetValue()).ToList();

		}

		public bool CloseDialog()
		{
			try
			{
				IWebElement closeCorner = this.containerElement.FindElement(By.XPath("..//a[@role='button']"), 2);
				if (closeCorner == null)
				{
					Report.Info("Did not find close button");
					return false;
				}
				else
				{
					return closeCorner.TryClick();
				}
			}
			catch (Exception)
			{
				Report.Info("Failed to close dialog by clicking on close button");
				SeleniumBrowser.WebBrowser.Close();
				return true;
			}

		}

	}

	class StudioSHAManagerProductSuspend : BaseObject
	{
		public const string BasePath = "//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool SelectRegulatorySpecialist(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='regulatoryusershold']"));
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SelectSubject(string option)
		{
			try
			{
				IWebElement statusSelect = this.containerElement.FindElement(By.XPath(".//select[@id='txtHoldSubject']"));
				if(option.Contains("�"))
				{
					string updatedOption= option.Replace("�", "–");
					statusSelect.Select(updatedOption);
					return statusSelect.SelectedOption() == updatedOption;
				}
				statusSelect.Select(option);
				return statusSelect.SelectedOption() == option;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool EnterSupplierMessage(string message)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldMessage']"));
			enterField.EnterText(message);
			return (enterField.GetValue() == message);
		}

		public bool AddSupplierMessage(string message)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldMessage']"));
			string originalMessage = this.GetSupplierMessage();
			enterField.SendKeys(" " + message);
			return (enterField.GetValue() == originalMessage + " " + message);
		}

		public string GetSupplierMessage()
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldMessage']"));
			return enterField.GetValue();
		}

		public bool EnterInternalProductNote(string note)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldNote']"));
			enterField.EnterText(note);
			return (enterField.GetValue() == note);
		}

		public bool AddInternalProductNote(string note)
		{
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldNote']"));
			string originalMessage = this.GetInternalProductNote();
			enterField.SendKeys(" " + note);
			return (enterField.GetValue() == originalMessage + " " + note);
		}



		public string GetInternalProductNote()
		{
			Report.Info("Beginning get internal product note");
			IWebElement enterField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtHoldNote']"));
			return enterField.GetValue();
		}

		public bool SelectClients(List<string> clientList)
		{
			bool allSucceeded = true;
			//uncheck all checkboxes
			IList<IWebElement> checkboxes = this.containerElement.FindElements(By.XPath(".//div[@id='holdcheckboxes']//input[@type='checkbox']"), 2);

			foreach (IWebElement thisCheckbox in checkboxes)
			{
				thisCheckbox.Check(false);
			}

			ReadOnlyCollection<IWebElement> optionLabels = this.containerElement.FindElements(By.XPath("(.//div[@id='holdcheckboxes']//label)|(.//div[@id='holdcheckboxes']//span)"));

			foreach (string client in clientList)
			{
				IWebElement checkbox = null;
				IWebElement matchingLabel = optionLabels.FirstOrDefault(x => x.GetValue().Contains(client));
				if (matchingLabel != null)
				{
					if (matchingLabel.TagName == "label")
					{
						checkbox = matchingLabel.FindElement(By.XPath(".//input"), 2);
					}
					else
					{
						checkbox = matchingLabel.FindElement(By.XPath(".//preceding-sibling::input[@type='checkbox']"), 2);
					}
				}

				if (checkbox != null)
				{
					checkbox.Check(true);
					if (!checkbox.Checked())
					{
						allSucceeded = false;
					}
				}
			}

			return allSucceeded;
		}


		public bool ClickButton(string button)
		{
			ReadOnlyCollection<IWebElement> buttonList = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]//button/span"));
			Report.Info(buttonList.Count + " buttons found");
			IWebElement matchingButton = buttonList.FirstOrDefault(x => x.GetValue().Trim() == button);
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

	class StudioSHAManagerProductUPC : BaseObject
	{
		public const string BasePath = "//h3[contains(text(),'SHA Manager Product UPC')]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait)
		{
			// Switch to window
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			Report.Info("Looking for SHA Manager Product UPC window");
			bool foundWindow = false;
			foreach (string handle in allHandles)
			{
				Report.Info("Checking handle: " + handle);
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h3[contains(text(),'SHA Manager Product UPC')]"), 2) != null)
				{
					Report.Success("Tab was switched successfully!");
					Report.Screenshot();
					foundWindow = true;
					break;
				}
			}
			if (!foundWindow)
			{
				Report.Failure("Failed to find the UPC List window ('SHA Manager Product UPC')");
				Report.Screenshot();
			}
			return base.Wait_for_load(30);


		}


	}

	public class Product
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

		public string Distributor { get; set; }
	}

	public class SHAManagerProdcutUPC
	{
		public string UPCNumber { get; set; }
		public string PackagingType { get; set; }
		public string PackagingSize { get; set; }
		public List<string> Retailers { get; set; }
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
			IWebElement el = this.containerElement.FindElement(By.XPath(".//select[@id='regulatoryusers']"), 2);
			el.Select(specialist);
			return el.SelectedOption() == specialist;
		}

		public bool ClickContinue()
		{
			return this.containerElement.FindElement(By.XPath(".//span[text()='Continue']"), 2).TryClick();
		}

		public bool ClickCancel()
		{
			return this.containerElement.FindElement(By.XPath(".//span[text()='Cancel']"), 2).TryClick();
		}

		public bool ClickClose()
		{
			return this.containerElement.FindElement(By.XPath(".//span[text()='Close']"), 2).TryClick();
		}
	}

	class AddProductToRecertificationDialog : BaseObject
	{
		public const string BasePath = "//div[@id='dialog-addToRecertification']";

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
			;
		}

		public List<string> GetReasons()
		{
			var reasons = new List<string>();
			ReadOnlyCollection<IWebElement> reasonTD =
				this.containerElement.FindElements(By.XPath(".//table[@id='tblReasons']//tr[(.//input)]/td[3]"));
			if (reasonTD.Count == 0)
			{
				Report.Error("No reasons have been found");
			}
			else
			{
				reasons = reasonTD.Select(x => x.GetValue()).ToList();
			}

			return reasons;
		}

		public List<string> GetSelectedReasons()
		{
			var reasons = new List<string>();
			ReadOnlyCollection<IWebElement> reasonTD =
				this.containerElement.FindElements(
					By.XPath(".//table[@id='tblReasons']//tr[(.//input[@checked='checked'])]/td[3]"));
			if (reasonTD.Count == 0)
			{
				Report.Info("No selected reasons have been found");
			}
			else
			{
				reasons = reasonTD.Select(x => x.GetValue()).ToList();
			}

			return reasons;
		}

		public bool SelectReasonByNumber(int no)
		{
			List<string> availableReasons = this.GetReasons();
			string pattern = @"^\d.0?";
			var regex = new Regex(pattern);
			string value = "";
			foreach (string thisReason in availableReasons)
			{
				Match match = regex.Match(thisReason);
				if (match.Success)
				{
					try
					{
						value = match.Value;
						int index = value.IndexOf(".");
						if (index > 0)
						{
							value = value.Substring(0, index);
						}

						if (Convert.ToInt16(value) == no)
						{
							return this.SelectReasonbyText(thisReason);
						}
					}
					catch (Exception e)
					{
						Report.Info(e.Message);
						continue;
					}

				}
			}

			return false;
		}

		public bool SelectReasonbyText(string reason)
		{
			Report.Info("Select by text: " + reason);
			//var reasonTD = containerElement.FindElements(By.XPath(".//table[@id='tblReasons']//tr[not(.//input[@checked='checked'])]/td[3]"));
			ReadOnlyCollection<IWebElement> reasonTD = this.containerElement.FindElements(By.XPath(".//table[@id='tblReasons']//tr/td[3]"));
			IWebElement matchingTD = reasonTD.FirstOrDefault(x => x.GetValue().Contains(reason));
			if (matchingTD == null)
			{
				Report.Info("No matching reason has been found");
				return false;
			}

			IWebElement matchingInput = matchingTD.FindElement(By.XPath("..//input"), 2);
			matchingInput.ScrollElementIntoView();
			Report.Screenshot();
			if (matchingInput == null)
			{
				Report.Info("No matching checkbox has been found");
				return false;
			}

			if (matchingInput.Checked())
			{
				Report.Info("Checkbox is already checked");
				return true;
			}

			if (matchingInput.TryClick())
			{
				return matchingInput.Checked();
			}

			return false;
		}

		public List<string> GetListOfAllowUserCheckboxesChecked()
		{
			var selected = new List<string>();
			ReadOnlyCollection<IWebElement> updateInputs = this.containerElement.FindElements(By.XPath(".//input[contains(@id, 'update')]"));
			foreach (IWebElement thisInput in updateInputs)
			{
				if (thisInput.Checked())
				{
					selected.Add(thisInput.FindElement(By.XPath("./.."), 2).GetValue().Trim());
				}
			}

			return selected;
		}

		public bool ClickButton(string button)
		{
			Report.Info("Beginning click button: " + button);
			ReadOnlyCollection<IWebElement> buttonList = this.containerElement.FindElements(By.XPath("./following-sibling::div//button/span"));
			Report.Info("Found " + buttonList.Count + " buttons");
			IWebElement matchingButton = buttonList.FirstOrDefault(x => x.GetValue().Trim() == button);
			if (matchingButton == null)
			{
				matchingButton =
					SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button/span[text()='" + button + "']"), 2);
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

	class StudioSHAManagerProductSubmissionRejection : BaseObject
	{

		public const string BasePath = "//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool SelectFirstSubject()
		{
			IWebElement firstSubject = this.containerElement.FindElement(By.XPath("//td[./b[text()='Select Subjects']]//input[position()=1]"));
			return firstSubject.TryClick();
		}

		public string GetSupplierMessage()
		{
			IWebElement messageField = this.containerElement.FindElement(By.XPath(".//textarea[@id='txtsubmittedRejectMessage']"));
			return messageField.GetValue();
		}

		/// <summary>
		/// Takes "Save" or "Cancel"
		/// </summary>
		/// <param name="button"></param>
		/// <returns></returns>
		public bool ClickButton(string button)
		{
			ReadOnlyCollection<IWebElement> buttonList = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]//button/span"));
			Report.Info(buttonList.Count + " buttons found");
			IWebElement matchingButton = buttonList.FirstOrDefault(x => x.GetValue().Trim() == button);
			if (matchingButton == null)
			{
				Report.Info("no matching button was found");
				return false;
			}
			return matchingButton.TryClick();
		}






	}

	class StudioSHAManagerUPCDetails : BaseObject
	{
		public const string BasePath = "//div[contains(@class,'ui-dialog ui-widget') and not ( contains(@style, 'display: none'))]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public IWebElement SelectClientInput => this.containerElement.FindElement(By.XPath(".//select[contains(@id,'clients')]"), 5);


	}

	class StudioSHAManagerUPCDetailsPopupTable : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(".//div[contains(@class,'ui-dialog ui-widget') and contains(@aria-labelledby,'upcDetails')]");

		public IWebElement UPCDetailsTable => this.containerElement.FindElement(By.XPath(".//table[@class='upcDetails']"), 30);

		public IWebElement CloseButton => this.containerElement.FindElement(By.XPath(".//button//span[text()='Close']"), 2);

		public IWebElement ObsoleteUPCButton => this.containerElement.FindElement(By.XPath(".//button//span[text()='Obsolete UPC']"), 2);



		//public bool UpcDeatilsTableLoaded()

		//{

		//	bool displayed = false;
		//	try
		//	{
		//		displayed = this.containerElement.FindElement(By.XPath(".//table[@class='upcDetails']"), 30).Displayed;
		//	}
		//	catch (NullReferenceException e)
		//	{
		//		displayed = false;
		//	}
		//	return displayed;
		//}

		public bool UpcDetailsTableLoadedOrNull(int secondsToWait)
		{
			bool loaded = false;

			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement detailsTable = this.containerElement.FindElement(By.XPath(".//table[@class='upcDetails']"), 30);

				if (detailsTable != null)
				{
					loaded = true;
					Report.Info("Table Loaded after: " + i + " seconds.");
					return loaded;

				}
			}
			return loaded;


		}

		public string DetailValue(string detailType)

		{
			IList<IWebElement> row = this.containerElement.FindElements(By.XPath(".//tbody//tr//td[1]"), 2).ToList();

			foreach (var item in row)
			{
				if (item.Text.Contains(detailType))

				{
					string valueBoxText = item.FindElement(By.XPath(".//following-sibling::td"), 2).Text;
					return valueBoxText;
				}

			}

			Report.Failure("The Row containing: " + detailType + " could not be found");
			return null;

		}

		public bool ObsoleteUPCButtonPresent()
		{
			bool displayStatus = this.ObsoleteUPCButton.FindElement(By.XPath(".//ancestor::button"), 2).Displayed;
			return displayStatus;
		}




	}
	class StudioSHAManagerUPCDetailsPopupObselteUPCConfrimrationPopup : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(".//div[contains(@class,'ui-dialog ui-widget') and contains(@aria-labelledby,'confirmationObsoleteModal')]");

		public IWebElement CancelButton => this.containerElement.FindElement(By.XPath(".//button[.//span[text()='Cancel']]"), 2);
		public IWebElement ContinueButton => this.containerElement.FindElement(By.XPath(".//button[.//span[text()='Continue']]"), 2);
		public bool ConfirmObseleteUPCMessage(string messageText)
		{
			string confirmObseleteUPCPopupText = this.FindElement(By.XPath(".//div[contains(@class,'dialog-content')]"), 2).Text;
			messageText = Regex.Replace(messageText, @"\s+", string.Empty);
			confirmObseleteUPCPopupText = Regex.Replace(confirmObseleteUPCPopupText, @"\s+", string.Empty);
			Report.Info($"The expected message is: {messageText}");
			Report.Info($"The found message is: {confirmObseleteUPCPopupText}");
			return confirmObseleteUPCPopupText == messageText;

		}

		public bool ContinueButtonPresent()
		{
			//bool displayStatus = this.ContinueButton.FindElement(By.XPath(".//ancestor::button"), 2).Displayed;

			return this.ContinueButton != null && this.ContinueButton.Displayed;
		}
		public bool CancelButtonPresent()
		{
			//bool displayStatus = this.CancelButton.FindElement(By.XPath(".//ancestor::button"), 2).Displayed;
			//return displayStatus;
			return this.CancelButton != null && this.CancelButton.Displayed;
		}
	}



	class StudioSHAManagerUPCDetailsPopupManagerValidationPopup : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath(".//div[contains(@class,'ui-dialog ui-widget') and contains(@aria-labelledby,'validate-pasword')]");

		public string ValidationPopupHeaderText => this.FindElement(By.XPath(".//span[@class='ui-dialog-title']"), 2).Text;

	}

}

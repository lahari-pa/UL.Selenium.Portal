using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class Distributor : NewProduct
	{

		private IWebElement DistSearchInput => SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//div[@class='table-search col-sm-4']//input[@id='inputGroup']"), 2);

		public string SearchIdNameField
		{
			get
			{
				IWebElement el = this.DistSearchInput;
				if (el != null)
				{
					return el.GetValue();
				}

				return "";
			}
			set
			{
				IWebElement el = this.DistSearchInput;
				if (el != null)
				{
					el.EnterText(value);
					el.SendKeys(Keys.Return);
					GeneralUtilities.Wait_for_load_finish();
				}
			}
		}

		public int ProductsInMyDistCount()
		{
			IList<IWebElement> productRows = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath("//div[@id='distributor']//table[contains(@class, 'table')]//tbody/tr"), 2);
			if (productRows == null || !productRows.Any())
			{
				return 0;
			}
			return productRows.Count(x => x.Displayed);
		}

		public bool ClickActionsApprove()
		{
			try
			{
				IList<IWebElement> distRow = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//table[@class='table']//tr"), 1).ToList();
				IWebElement button = distRow.FirstOrDefault()?.FindElement(By.XPath("//a[contains(@class,'btn btn-link btn-xs') and contains(text(),'Approve')]"), 1);
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ClickExpandOnFirstRow()
		{
			try
			{
				IList<IWebElement> distRow = SeleniumWebDriver.CurrentDriver.FindElements(By.XPath(".//table[@class='table table-hover upc-table']//tr"), 1).ToList();
				IWebElement button = distRow.FirstOrDefault()?.FindElement(By.XPath("//em[contains(@class,'fa fa-chevron-right')]"), 1);
				return button.TryClick();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool EditUpcInformation(UpcInformation info)
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);
				IWebElement ProductNameOnlabel = container.FindElement(By.XPath(".//label[contains(text(),'Product Name on Label')]/..//input"), 2);

				if (ProductNameOnlabel == null)
				{
					Report.Info(@"Failed to find 'Size' input in the format ""Size (.. Ounces)""");
					return false;
				}
				ProductNameOnlabel.EnterText(info.UPCName);


				if (info.ContainerType.ToLower() != "none")
				{
					IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);

					if (containsType == null)
					{
						return false;
					}

					containsType.Select(info.ContainerType);
				}

				string regex = @"(.*)\((.*)\)";
				IWebElement sizeField = (from input in textInputs
										 let match = Regex.Match(input.GetAttribute("placeholder"), regex)
										 where match.Success && match.Groups[1].Value.StartsWith("Size") && match.Groups[2].Value.Contains("Ounces")
										 select input).FirstOrDefault();
				if (sizeField == null)
				{
					Report.Info(@"Failed to find 'Size' input in the format ""Size (.. Ounces)""");
					return false;
				}
				sizeField.EnterText(info.Size);
				if (info.Dpci.Length > 0)
				{
					IWebElement dpciField = container.FindElement(By.XPath(".//input[contains(@data-bind,'value.field')]"), 2);

					if (dpciField == null)
					{
						return false;
					}
					dpciField.EnterText(info.Dpci);
				}

				if (info.Quantity.Length > 0)
				{
					IWebElement quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity']"), 2);

					if (quantityField == null)
					{
						return false;
					}
					quantityField.EnterText(info.Quantity);
				}

				if (info.PackageType.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'Package Type')]"), 2);

					if (packageField == null)
					{
						return false;
					}
					packageField.Select(info.PackageType);
				}
				return true;
			}
			catch (Exception ex)
			{
				Report.Info(ex.Message);
				return false;
			}
		}
	}
}

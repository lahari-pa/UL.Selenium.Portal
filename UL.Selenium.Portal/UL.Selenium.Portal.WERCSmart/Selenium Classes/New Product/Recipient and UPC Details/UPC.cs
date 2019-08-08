using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using NTTQA.Selenium.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class UPC : NewProduct
	{
		public bool ClickAddCaseUpcButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public bool EnterCaseUPCInformation(TableRow row)
		{
			if (row["UPC Number"].ToLower().Contains("saved as"))
			{
				try
				{
					string savedUPC = Context
						.GetFromContext(row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					row["UPC Number"] = savedUPC;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + row["UPC Number"].Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}
			}

			IWebElement upcNumber = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'UPC Number')]"), 2);
			if (upcNumber == null || !upcNumber.TryEnterText(row["UPC Number"]))
			{
				Report.Info("Failed to enter the UPC Number in the Add UPC modal window.");
				return false;
			}

			IWebElement containerType = this.containerElement.FindElement(By.XPath(@"//select[contains(@data-bind,'Container Type')]"), 2);
			if (containerType == null)
			{
				Report.Info("Failed to select container type from the Container Type drop down");
				return false;
			}
			else
			{
				containerType.Select(row["Container Type"]);
			}

			IWebElement size = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'Size (Weight Ounces)')]"), 2);
			if (size == null || !size.TryEnterText(row["Size (Weight Ounces)"]))
			{
				Report.Info("Failed to enter the Size (Weight Ounces) in the Add Case UPC modal window.");
				return false;
			}

			IWebElement quantity = this.containerElement.FindElement(By.XPath(@"//input[@type='text' and contains(@placeholder,'Quantity of Units within the Case')]"));
			if (quantity == null || !quantity.TryEnterText(row["Quanity of Units within the Case"]))
			{
				Report.Info("Failed to enter the Quanity of Units within the Case in the Add Case UPC modal window.");
				return false;
			}

			IWebElement transportation = this.containerElement.FindElement(By.XPath(@"//select[contains(@data-bind,'Transportation Options')]"), 2);
			if (transportation == null)
			{
				Report.Info("Failed to select type from the Type drop down");
				return false;
			}
			else
			{
				transportation.Select(row["Transportation Options"]);
			}

			Report.Info("Successfully entered all Case UPC information.");
			return true;
		}

		public string LithiumBatteyWarning()
		{
			//this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath("//div[contains(text(), 'Lithium battery registrations')]"), 2).Text;
		}

		public string MaximumLimitUpcWarning()
		{
			//this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath("//p[@class='marBot-0' and contains(text(), 'maximum limit' )]"), 2).Text;
		}

		public List<string> GetUPCOptions()
		{
			IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
			var rList = new List<string>();
			if (container != null)
			{
				rList = container.FindElements(By.XPath("//tbody//div[@class='form-group']")).Select(x => x.Text.Trim()).ToList();
				rList.Select(x => x.Replace("\r\n", " ").Split(' ').FirstOrDefault()).ToList();
			}
			return rList;
		}

		public List<string> GetUPCbuttons()
		{
			return this.containerElement.FindElements(By.XPath("//button[@class='btn btn-success']"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool AddCaseUpcButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}


		public bool AddUpcButton()
		{
			IWebElement el = this.containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}

		public bool InputUpcCaseInformation(UpcCaseInformation info)
		{
			try
			{
				IWebElement container = this.containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				IList<IWebElement> textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				IWebElement upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					try
					{
						string savedUPC = Context
							.GetFromContext(info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						info.UpcNumber = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}

				}
				upcNumberField.EnterText(info.UpcNumber);
				IWebElement containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				containsType.Select(info.ContainerType);
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

				if (info.Quantity.Length > 0)
				{
					IWebElement quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity of Units within the Case']"), 2);
					quantityField.EnterText(info.Quantity);
				}

				if (info.IndividualUpcCasePack.ToLower().Contains("saved as"))
				{
					try
					{
						var savedUPC = Context
							.GetFromContext(info.IndividualUpcCasePack.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
							.ToString();
						info.IndividualUpcCasePack = savedUPC;
					}
					catch (Exception e)
					{
						Report.Info("Failed to find saved item in context: " + info.IndividualUpcCasePack.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
						throw;
					}

				}

				if (info.IndividualUpcCasePack.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'upcContained.field')]"), 2);
					packageField.Select(info.IndividualUpcCasePack);
				}

				if (info.TransportationOption.Length > 0)
				{
					IWebElement packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'transport.field')]"), 2);
					if (info.TransportationOption.ToLower().Contains("random"))
					{
						var packageOptions = packageField.FindElements(By.XPath(".//option")).Select(x => x.GetValue()).ToList();
						var r = new Random();
						int rInt = r.Next(0, packageOptions.Count - 1);
						packageField.Select(packageOptions[rInt]);
					}
					else
					{
						packageField.Select(info.TransportationOption);
						GeneralUtilities.TrySelect(packageField, info.TransportationOption, true);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Report.Info(ex.Message);
				return false;
			}
		}


		public List<string> UpcPageLinks()
		{
			var linksText = new List<string>();
			linksText = this.containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']//a")).Select(x => x.Text).ToList();
			return linksText;
		}

		public List<string> GetUPCErrorsForSection(string section)
		{
			string xPath = @"(.//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//label[@class='sr-only'][contains(text(),""" + section + @""")])] | " +
						@".//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//select[@class='form-control']//option[contains(text(),""" + section + @""")])])";
			IList<IWebElement> el = this.containerElement.FindElements(By.XPath(xPath), 10);
			return el.Count == 0 ? new List<string>() : el.Select(x => x.Text).ToList();
		}


		public bool SelectRadio(string section, string value)
		{
			string xPath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]";
			IWebElement el = this.containerElement.FindElement(By.XPath(xPath), 2);
			if (el != null)
			{
				return el.TryClick();
			}
			Report.Error("Could not find the correct input in section: " + section);
			return false;
		}

		public string GetErrorText()
		{
			string text = "";
			IWebElement foundText = this.containerElement.FindElement(By.XPath("//ul[@class='form-error']//li"), 2);
			if (foundText != null)
			{
				text = foundText.Text;
			}
			return text;
		}
	}

	public class UpcCaseInformation
	{
		public string UpcNumber { get; set; } = "";
		public string ContainerType { get; set; } = "";
		public string Size { get; set; } = "";
		public string Quantity { get; set; } = "";
		public string IndividualUpcCasePack { get; set; } = "";
		public string TransportationOption { get; set; } = "";
	}
}

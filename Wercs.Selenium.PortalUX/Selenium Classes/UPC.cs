using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Automation_Classes.Universal_Functions;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using Org.BouncyCastle.Crypto.Engines;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class UPC : NewProduct
	{
		public bool ClickAddCaseUpcButton()
		{
			var el = containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return el.TryClick();
		}

		public string LithiumBatteyWarning()
		{
			this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath("//div[contains(text(), 'Lithium battery registrations')]"), 2).Text;
		}

		public string MaximumLimitUpcWarning()
		{
			this.RefreshContainer();
			return this.containerElement.FindElement(By.XPath("//p[@class='marBot-0' and contains(text(), 'maximum limit' )]"), 2).Text;
		}

		public List<string> GetUPCOptions()
		{
			var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
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
			return containerElement.FindElements(By.XPath("//button[@class='btn btn-success']"), 2).Select(x => x.GetValue()).ToList();
		}

		public bool AddCaseUpcButton()
		{
			var el = containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewPackRow')]"), 2);
			if (el == null)
			{
				return false;
			}

			return true;
		}


		public bool AddUpcButton()
		{
			var el = containerElement.FindElement(By.XPath(".//button[contains(@data-bind,'addNewRow')]"), 2);
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
				var container = containerElement.FindElement(By.XPath(".//table[@class='table table-hover upc-table']"), 2);
				var textInputs = container.FindElements(By.XPath("//input[@type = 'text']"), 2);
				var upcNumberField = container.FindElement(By.XPath(".//label[contains(text(),'UPC Number')]/..//input"), 2);

				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					try
					{
						var savedUPC = Context
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
				var containsType = container.FindElement(By.XPath(".//select[contains(@data-bind,'Container Type')]"), 2);
				containsType.Select(info.ContainerType);
				var regex = @"(.*)\((.*)\)";
				var sizeField = (from input in textInputs
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
					var quantityField = container.FindElement(By.XPath(".//input[@placeholder='Quantity of Units within the Case']"), 2);
					quantityField.EnterText(info.Quantity);
				}

				if (info.IndividualUpcCasePack.Length > 0)
				{
					var packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'upcContained.field')]"), 2);
					packageField.Select(info.IndividualUpcCasePack);
				}

				if (info.TransportationOption.Length > 0)
				{
					var packageField = container.FindElement(By.XPath(".//select[contains(@data-bind,'transport.field')]"), 2);
					if (info.TransportationOption.ToLower().Contains("random"))
					{
						List<string> packageOptions = packageField.FindElements(By.XPath(".//option")).Select(x=>x.GetValue()).ToList();
						Random r = new Random();
						int rInt = r.Next(0, packageOptions.Count-1);
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
			linksText = containerElement.FindElements(By.XPath(".//div[@class='alert alert-info']//a")).Select(x => x.Text).ToList();
			return linksText;
		}

		public List<string> GetUPCErrorsForSection(string section)
		{
			var xPath = @"(.//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//label[@class='sr-only'][contains(text(),""" + section + @""")])] | " +
						@".//p[(.//ancestor::p[@class='form-error']) and (.//ancestor::div[starts-with(@class, 'form-group has-error')]//select[@class='form-control']//option[contains(text(),""" + section + @""")])])";
			var el = containerElement.FindElements(By.XPath(xPath), 10);
			return el.Count == 0 ? new List<string>() : el.Select(x => x.Text).ToList();
		}


		public bool SelectRadio(string section, string value)
		{
			var xPath = @"//span[(.//ancestor::div[starts-with(@class,'form-group')]//label[starts-with(text(),""" + section + @""")]) and contains(text(),'" + value + "') and (./preceding-sibling::input[@type='radio'])]";
			var el = this.containerElement.FindElement(By.XPath(xPath), 2);
			if (el != null)
			{
				return el.TryClick();
			}
			Report.Error("Could not find the correct input in section: " + section);
			return false;
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

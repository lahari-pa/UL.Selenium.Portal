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
using System.IO;
using NTTQA.Selenium.Classes;

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

		public bool ClickSampleFileLink()
		{
			return this.FindElement(By.XPath("//a[@class='alert-link']")).TryClick();
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

		internal bool VerifySampleFile(Table table, string file, string savedAs)
		{
			this.GetFile(file, savedAs);
			var actualFile = Context.GetFromContext(savedAs);
			List<string> fileData = GetFileData(savedAs, actualFile);

			var tableData = new List<string>();
			tableData.AddRange(table.Header);
			foreach (TableRow row in table.Rows)
			{
				tableData.AddRange(row.Values.ToList());
			}

			if (tableData is null || fileData is null)
			{
				Report.Failure("Either the table is empty or the file: '" + file + "' is not being read.");
				return false;
			}

			for (int i = 0; i < tableData.Count; i++)
			{
				if (tableData[i].Trim() != fileData[i].Trim())
				{
					Report.Info("Error: Table Data contains: " + tableData[i] + " while File Data contains: " + fileData[i] + " in row " + i);
					return false;
				}
			}
			return true;
		}

		private List<string> GetFileData(string savedAs, object actualFile)
		{
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			if (Report.IsTrue(actualFile != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + actualFile.ToString()))
			{
				var ExcelUtils = new ExcelUtilities(actualFile.ToString(), "Sheet1");
				Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");
				List<string> FirstRow = ExcelUtils.Excel_GetRow(0);
				Report.Info("Header row contained: '" + string.Join("', '", FirstRow) + "'");

				var list = new List<string>();

				for (int i = 0; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					list.AddRange(ExcelUtils.Excel_GetRow(i));
				}
				Report.IsTrue(list != null, "Excel did not contain any product data!", "Excel file contained product data, as expected!");
				return list;
			}
			return null;
		}

		private void GetFile(string file, string savedAs)
		{
			Report.Info("Confirm Excel file is downloaded with name: " + file);
			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);
			string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
			if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
			{
				Context.AddToContext(savedAs, dir.FirstOrDefault());
			}
		}

		public bool DeleteFileFromDownloadsFolder(string file)
		{
			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Deleting any existing files with name: " + file + " in the directory: " + downloadsFolder + ".");
			string dir = Directory.GetFiles(downloadsFolder, file, SearchOption.AllDirectories).ToString();
			if (string.IsNullOrEmpty(dir.Trim()))
			{
				File.Delete(dir);
			}

			if (Directory.EnumerateFiles(downloadsFolder, file, SearchOption.AllDirectories).Count() > 0)
			{
				return true;
			}
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

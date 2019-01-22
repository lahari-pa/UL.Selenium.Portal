using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using Org.BouncyCastle.Crypto.Engines;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.New_Product
{
	class PesticideDetailsState : NewProduct
	{
		public int StateRowsCount()
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Info("The State Pesticide Registration table could not be found");
				Report.Screenshot();
				return -1;
			}

			var rowInputs = epaTable.FindElements(By.XPath(@".//tr/td/input"), 2);
			if (rowInputs.Count == 0)
			{
				Report.Info("There were no State Pesticide Registration rows visible on the Pesticide State Registration Details page");
				Report.Screenshot();
				return -1;
			}

			Report.Info("There are " + rowInputs.Count + " State Pesticide Registration rows showing");
			return rowInputs.Count;
		}

		public bool StatePesticideRegistrationNumberIsEdited(int row)
		{
			try
			{
				var epaTable = this.EPATable();
				if (epaTable == null)
				{
					Report.Info("The State Pesticide Registration table could not be found");
					Report.Screenshot();
					return false;
				}

				var rowInputs = epaTable.FindElements(By.XPath(@".//tr/td/input"), 2);
				if (rowInputs.Count == 0)
				{
					Report.Info("There were no State Pesticide Registration rows visible!");
					Report.Screenshot();
					return false;
				}

				Report.Info("Found " + rowInputs.Count + " rows in the State Pesticide Registration table");
				var currentRow = rowInputs[row];
				currentRow.ScrollElementIntoView();
				var rowText = currentRow.GetAttribute("value");
				Delay.Seconds(1);
				return rowText.EndsWith("-edited");
			}
			catch (IndexOutOfRangeException ex)
			{
				Report.Failure($"The specified row to check ({row}) exceeded the row count!");
				throw new Exception(ex.Message);
			}
		}

		public bool AddSuffixToPesticideRegistrationNumber(int row)
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Info("The State Pesticide Registration table could not be found");
				Report.Screenshot();
				return false;
			}

			var rowInputs = epaTable.FindElements(By.XPath(@".//tr/td/input"), 2);
			if (rowInputs.Count == 0)
			{
				Report.Info("There were no State Pesticide Registration rows visible!");
				Report.Screenshot();
				return false;
			}

			var currentRow = rowInputs[row];
			currentRow.SendKeys("-edited");
			Delay.Seconds(1);
			return currentRow.GetValue().EndsWith("-edited");
		}

		public bool StateRowHasExpirationDate(int row)
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Screenshot();
				throw new Exception("The State Pesticide Registration table could not be found");
			}

			var expirationDateInputs = epaTable.FindElements(By.XPath(@".//tr/td/div/input"));
			if (expirationDateInputs.Count == 0)
			{
				Report.Screenshot();
				throw new Exception("There were no Pesticide State Registration Expiration Date rows visible");
			}

			var currentInput = expirationDateInputs[row];
			var expirationDateText = currentInput.GetAttribute("value");
			return !expirationDateText.IsNullOrEmpty();
		}

		public bool ClickEpaKellyServicesLink()
		{
			var links = this.containerElement.FindElements(By.XPath(
				@".//div[@class='panel-heading']/following-sibling::div//span[contains(text(),'Update WERCSmart data with EPA data through Kelly Services')]"));
			if (links == null || links.Count == 0)
			{
				Report.Info("No (span) links showing with text 'Update WERCSmart data...'");
				Report.Screenshot();
				return false;
			}

			var clicked = links.First().TryClick();
			GeneralUtilities.Wait_for_load_finish();
			this.RefreshContainer();
			return clicked;
		}

		/// <summary>
		/// returns whether a tick appears under column 'Is Kelly Data?' overloads: int for row index, string for state
		/// </summary>
		public bool KellyDataIsTicked(int index)
		{
			try
			{
				this.RefreshContainer();
				var epaTable = this.EPATable();
				if (epaTable == null)
				{
					Report.Screenshot();
					throw new Exception("The State Pesticide Registration table could not be found!");
				}

				var rows = epaTable.FindElements(By.XPath(@".//tr[contains(@data-bind, 'css')]"), 2);
				if (rows.Count == 0)
				{
					Report.Screenshot();
					throw new Exception("No rows were found in the State Pesticide Registration table!");
				}

				var stateRow = rows[index];
				var kellyDataCheck = stateRow.FindElement(By.XPath(@"//td/div[@class='fa fa-check' and not(contains(@style, 'display: none'))]"), 2);
				if (kellyDataCheck == null)
				{
					return false;
				}
				return true;
			}
			catch (IndexOutOfRangeException ex)
			{
				Report.Failure("The specified index " + index + " was greater than the number of rows in the table!");
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// returns whether a tick appears under column 'Is Kelly Data?' overloads: int for row index, string for state
		/// </summary>
		public bool KellyDataIsTicked(string state)
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Screenshot();
				throw new Exception("The State Pesticide Registration Table could not be found");
			}

			var kellyDataTick = epaTable.FindElement(By.XPath(
				@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/ancestor::tr/td/div[@class='fa fa-check' and not(contains(@style, 'display: none'))]"), 2);
			if (kellyDataTick == null)
			{
				return false;
			}

			kellyDataTick.ScrollElementIntoView();
			return true;
		}

		public bool EditExpirationDate(string date, string state)
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}

			var expirationDateInputs = epaTable.FindElements(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/div/input[@type='text']"), 2);
			if (expirationDateInputs.IsNullOrEmpty())
			{
				Report.Failure("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return false;
			}
			expirationDateInputs.First().Clear();
			expirationDateInputs.First().SendKeys(date);
			expirationDateInputs.First().SendKeys(Keys.Enter);
			expirationDateInputs.First().ScrollElementIntoView();
			Delay.Seconds(1);
			return expirationDateInputs.First().GetValue() == date;
		}

		public string ExpirationDate(string state)
		{
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Info("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}

			var expirationDateInput = epaTable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/div/input[@type='text']"), 2);
			if (expirationDateInput == null)
			{
				Report.Info("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return null;
			}

			expirationDateInput.ScrollElementIntoView();
			return expirationDateInput.GetValue();
		}

		public string GetPesticideRegKellyExpirationDate(string state)
		{
			var EPATable = this.EPATable();
			if (EPATable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}

			var kellyExpirationDateInput = EPATable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/following-sibling::td/label"), 2);
			if (kellyExpirationDateInput == null)
			{
				Report.Failure("Failed to find a match on the State text: '" + state + "'");
				Report.Screenshot();
				return null;
			}

			return kellyExpirationDateInput.GetValue();
		}

		public string ErrorMessageForState(string state)
		{
			this.RefreshContainer();
			//return this.containerElement.FindElements(By.XPath(".//p[@class='form-error']//span"), 2)?.Select(x => x.Text).ToList();

			return null;
		}

		public List<StatePesticideRegistration> GetStatePesticideRegistrationDetails()
		{
			var allResults = new List<StatePesticideRegistration>();
			var epaTable = this.EPATable();
			if (epaTable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return allResults;
			}
			var rows = epaTable.FindElements(By.XPath(".//tbody/tr")).ToList();
			Report.Info("Getting state data for: " + rows.Count + " rows");
			foreach (var thisRow in rows)
			{
				var State = thisRow.FindElement(By.XPath(".//td[2]//div")).Text;
				var ExpirationDate = thisRow.FindElement(By.XPath(".//td[3]//input")).GetValue();
				var RegNo = thisRow.FindElement(By.XPath(".//td[1]//input"));
				var RegistrationNumber = RegNo.Text;
				if (RegistrationNumber.Length == 0)
				{
					RegistrationNumber = RegNo.GetAttribute("placeholder");
				}
				var KellyDate = "";
				if (thisRow.FindElement(By.XPath(".//td[4]//label")) != null)
				{
					KellyDate = thisRow.FindElement(By.XPath(".//td[4]//label")).Text;
				}
				var IsKellyData = false;
				if (thisRow.FindElements(By.XPath(".//td[5]//div")) != null)
				{
					IsKellyData = thisRow.FindElements(By.XPath(".//td[5]//div")).Count == 1;
				}
				allResults.Add(new StatePesticideRegistration() {
					State = State,
					ExpirationDate = ExpirationDate,
					RegistrationNumber = RegistrationNumber,
					ExpirationDateByKelly = KellyDate,
					IsKellyData = IsKellyData
				});
			}
			return allResults;
		}

		public class StatePesticideRegistration
		{
			public string RegistrationNumber { get; set; }
			public string State { get; set; }
			public string ExpirationDate { get; set; }
			public string ExpirationDateByKelly { get; set; }
			public bool IsKellyData { get; set; }
		}
	}
}

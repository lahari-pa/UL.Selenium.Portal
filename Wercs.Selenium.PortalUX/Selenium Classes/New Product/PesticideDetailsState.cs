using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Components.DictionaryAdapter;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.New_Product
{
	class PesticideDetailsState : NewProduct
	{
		public IWebElement StateRegistrationRow(string state)
		{
			return this.Table()?.FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
		}

		public int StateRowsCount()
		{
			var epaTable = this.Table();
			if (epaTable == null)
			{
				Report.Error("The State Pesticide Registration table could not be found");
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
				var epaTable = this.Table();
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

		public bool ClickEpaKellyServicesLink()
		{
			var links = this.containerElement.FindElements(By.XPath(@".//div[@class='panel-heading']/following-sibling::div//span[contains(text(),'Update WERCSmart data with EPA data through Kelly Services')]"));
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

		public bool EditExpirationDate(string value, string state)
		{
			var row = this.StateRegistrationRow(state);
			if (row == null)
			{
				Report.Error("Failed to located State Registration table row for state: " + state);
				return false;
			}
			var input = row.FindElement(By.XPath("./td/div/input"), 2);
			if (input == null)
			{
				Report.Error("Failed to find the text input for Expiration date on the state row: " + state);
				return false;
			}
			input.Clear();
			input.EnterText(value);
			input.SendKeys(Keys.Enter);
			return input.GetValue() == value;
		}

		public bool EditRegistrationNumber(string value, string state)
		{
			var row = this.StateRegistrationRow(state);
			if (row == null)
			{
				Report.Error("Failed to located State Registration table row for state: " + state);
				return false;
			}
			var input = row.FindElement(By.XPath("./td/input"), 2);
			input.Clear();
			input.EnterText(value);
			return input.GetValue() == value;
		}

		public string ExpirationDate(string state)
		{
			var epaTable = this.Table();
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
			var EPATable = this.Table();
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

		public bool CalenderDatePickerDisplayed(string state)
		{
			var calendar = SeleniumBrowser.WebBrowser.FindElement(By.XPath(@".//div[@class='datepicker-days']"), 2);
			return calendar != null && calendar.Displayed;
		}

		public bool SelectExpirationDateFromCalendar(string state, DateTime date)
		{
			var table = this.Table();
			if (table == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			var calendarButton = table.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td//span[@class='input-group-addon']"), 2);
			// try a few times to click the caldendar button
			var attempt = 0;
			while (!this.CalenderDatePickerDisplayed(state) && attempt < 5)
			{
				calendarButton.ScrollElementIntoView();
				if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
				{
					break;
				}
				this.Table().SendKeys(Keys.PageUp);
				if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
				{
					break;
				}
				this.Table().SendKeys(Keys.PageUp);
				if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
				{
					break;
				}
				Report.Info("Failed to click the calender button.Trying again...");
				attempt++;
			}
			if (!this.CalenderDatePickerDisplayed(state))
			{
				Report.Failure("Failed to click the calendar button to open the calender datepicker for state: " + state);
				Report.Screenshot();
				return false;
			}
			//if (!calendarButton.TryClick())
			//{
			//	var inputEl = EPATable.FindElement(By.XPath(@"..//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td//input"), 2);
			//	if (!inputEl.TryClick())
			//	{
			//		Report.Failure("Could not click calender button for state: " + state);
			//		Report.Screenshot();
			//		return false;
			//	}
			//}
			if (!this.GetCalendarActiveDate(out var startMonth, out var startYear))
			{
				Report.Failure("Failed to get active date from calendar date selector!");
				Report.Screenshot();
				return false;
			}
			//var activeDate = this.CalendarActiveDate();
			//if (activeDate == null)
			//{
			//	Report.Failure("Unable to locate the active date (Month Year) in the EPA calendar pop up for state: " + state);
			//	Report.Screenshot();
			//	return false;
			//}
			var activeYear = int.Parse(startYear);
			var activeMonth = DateTime.ParseExact(startMonth, "MMMM", CultureInfo.CurrentCulture).Month;
			// Fail test if target date preceeds the default Month Year on the calendar
			if (date.Year < activeYear || date.Year == activeYear && date.Month < activeMonth)
			{
				Report.Failure("Target date must be equal or later than the current active date on the calendar");
				Report.Screenshot();
				return false;
			}
			// Perform loop until target year = active year and target month = active month
			while (date.Year > activeYear || date.Year == activeYear && date.Month > activeMonth)
			{
				// Click next month
				SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//th[@class='next']"), 2).TryClick();
				//activeDate = this.CalendarActiveDate();
				if (!this.GetCalendarActiveDate(out var month, out var year))
				{
					Report.Failure("Failed to get active date from calendar date selector!");
					Report.Screenshot();
					return false;
				}
				activeYear = int.Parse(year);
				activeMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
			}
			// Select day
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//td[@class='day' and text()='" + date.Day + "']"), 2).TryClick();
		}

		public bool GetCalendarActiveDate(out string month, out string year)
		{
			var calendarTable = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]"), 2);
			var datePicker = calendarTable?.FindElement(By.XPath(".//th[@class='datepicker-switch']"), 2);
			var dates = datePicker?.Text.Split(' ').Select(x => x.Trim()).ToList();
			month = "";
			year = "";
			if (dates != null && dates.Count == 2)
			{
				month = dates[0];
				year = dates[1];
				return true;
			}
			return false;
		}

		public string TableRowClassColour(string state)
		{
			var epaRow = this.Table().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
			if (epaRow == null)
			{
				Report.Failure("Unable to locate EPA table row for state: " + state);
				return null;
			}
			// Hack for screenshots - Don't scroll to row if we're looking at the top 4 states, because they are obscured by the banner
			if (new[] { "AK", "AL", "AR", "AZ" }.All(x => x != state))
			{
				epaRow.ScrollElementIntoView();
			}
			var colourCode = epaRow.GetAttribute("class");
			return colourCode?.Replace("rpds-", "");
		}

		public string TableRowBackgroundHex(string state)
		{
			var epaRow = this.Table().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
			if (epaRow == null)
			{
				Report.Failure("Unable to locate EPA table row for state: " + state);
				return null;
			}
			return epaRow.GetCssValue("background-color");
		}

		public List<StatePesticideRegistration> GetStatePesticideRegistrationDetails()
		{
			var rStatePest = new List<StatePesticideRegistration>();
			Delay.Seconds(3);
			var epaTable = this.Table();
			if (epaTable == null)
			{
				Report.Failure("The EPA Registration Table could not be found");
				Report.Screenshot();
				return rStatePest;
			}
			var expectedHeadings = new List<string> {
				"State Pesticide Registration #",
				"State",
				"Expiration Date",
				"Expiration Date provided by Kelly",
				"Is Kelly Data"
			};
			var headings = this.TableColumnHeadings();
			if (!expectedHeadings.All(x => headings.Contains(x)))
			{
				Report.Error("The table headings did not match those expected! => " + string.Join(", ", expectedHeadings));
				Report.Screenshot();
				return null;
			}
			var rows = epaTable.FindElements(By.XPath(".//tbody/tr")).ToList();
			Report.Info("Getting state data for: " + rows.Count + " rows");
			foreach (var thisRow in rows)
			{
				var state = thisRow.FindElement(By.XPath($".//td[position() = {headings.IndexOf(expectedHeadings[1]) + 1}]//div")).Text;
				var expirationDate = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[2]) + 1}]//input")).GetValue();
				var registrationNumberEl = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[0]) + 1}]//input"));
				var registrationNumber = registrationNumberEl.GetValue();
				if (registrationNumber.Length == 0)
				{
					registrationNumber = registrationNumberEl.GetAttribute("placeholder");
				}
				var kellyDate = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[3]) + 1}]//label"))?.Text;
				var isKellyData = thisRow.FindElements(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[4]) + 1}]//div")).Count == 1;
				rStatePest.Add(new StatePesticideRegistration() {
					State = state,
					ExpirationDate = expirationDate,
					RegistrationNumber = registrationNumber,
					ExpirationDateByKelly = kellyDate,
					IsKellyData = isKellyData
				});
			}
			return rStatePest;
		}

		public class StatePesticideRegistration
		{
			public string RegistrationNumber { get; set; }

			public string State { get; set; }

			public string ExpirationDate { get; set; }

			public string ExpirationDateByKelly { get; set; }

			public bool IsKellyData { get; set; }

			public bool EditExpirationDate(string value)
			{
				return new PesticideDetailsState().EditExpirationDate(value, this.State);
			}

			public bool EditRegistrationNumber(string value)
			{
				Report.Info("Beginning edit registration number: " + value);
				return new PesticideDetailsState().EditRegistrationNumber(value, this.State);
			}

			//public bool CickRemove()
			//{
			//	return false;
			//}
		}
	}
}

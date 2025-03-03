using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class PesticideDetailsState : NewProduct
	{
		public IWebElement StateRegistrationRow(string state)
		{
			return this.Table()?.FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
		}

		public int StateRowsCount()
		{
			IWebElement epaTable = this.Table();
			if (epaTable == null)
			{
				Report.Error("The State Pesticide Registration table could not be found");
				Report.Screenshot();
				return -1;
			}

			IList<IWebElement> rowInputs = epaTable.FindElements(By.XPath(@".//tr/td/input"), 2);
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
				IWebElement epaTable = this.Table();
				if (epaTable == null)
				{
					Report.Info("The State Pesticide Registration table could not be found");
					Report.Screenshot();
					return false;
				}
				IList<IWebElement> rowInputs = epaTable.FindElements(By.XPath(@".//tr/td/input"), 2);
				if (rowInputs.Count == 0)
				{
					Report.Info("There were no State Pesticide Registration rows visible!");
					Report.Screenshot();
					return false;
				}
				Report.Info("Found " + rowInputs.Count + " rows in the State Pesticide Registration table");
				IWebElement currentRow = rowInputs[row];
				currentRow.ScrollElementIntoView();
				string rowText = currentRow.GetAttribute("value");
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
			System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> links = this.containerElement.FindElements(By.XPath(@".//div[@class='panel-heading']/following-sibling::div//span[contains(text(),'Update WERCSmart data with EPA data through Kelly Solutions')]"));
			if (links == null || links.Count == 0)
			{
				Report.Info("No (span) links showing with text 'Update WERCSmart data...'");
				Report.Screenshot();
				return false;
			}
			bool clicked = links.First().TryClick();
			GeneralUtilities.Wait_for_load_finish();
			//this.RefreshContainer();
			return clicked;
		}

		public bool EditExpirationDate(string value, string state)
		{
			IWebElement row = this.StateRegistrationRow(state);
			if (row == null)
			{
				Report.Error("Failed to located State Registration table row for state: " + state);
				return false;
			}
			IWebElement input = row.FindElement(By.XPath("./td/div/input"), 2);
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
			IWebElement row = this.StateRegistrationRow(state);
			if (row == null)
			{
				Report.Error("Failed to located State Registration table row for state: " + state);
				return false;
			}
			IWebElement input = row.FindElement(By.XPath("./td/input"), 2);
			input.Clear();
			input.EnterText(value);
			return input.GetValue() == value;
		}

		public string ExpirationDate(string state)
		{
			IWebElement epaTable = this.Table();
			if (epaTable == null)
			{
				Report.Info("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}
			IWebElement expirationDateInput = epaTable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/div/input[@type='text']"), 2);
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
			IWebElement epaTable = this.Table();
			if (epaTable == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return null;
			}

			IWebElement kellyExpirationDateInput = epaTable.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td/following-sibling::td/label"), 2);
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
			IWebElement calendar = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@".//div[@class='datepicker-days']"), 2);
			return calendar != null && calendar.Displayed;
		}

		public bool SelectExpirationDateFromCalendar(string state, DateTime date)
		{
			IWebElement table = this.Table();
			if (table == null)
			{
				Report.Failure("The State Pesticide Registration Table could not be found");
				Report.Screenshot();
				return false;
			}
			IWebElement calendarButton = table.FindElement(By.XPath(@".//tr[contains(@data-bind, 'css')]//div[text()='" + state + "']/ancestor::td/following-sibling::td//span[@class='input-group-addon']"), 2);
			// try a few times to click the caldendar button
			int attempt = 0;
			while (!this.CalenderDatePickerDisplayed(state) && attempt < 10)
			{
				try
				{
					//calendarButton.ScrollElementIntoView();
					if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
					{
						break;
					}

					//calendarButton.ScrollElementIntoView();

					//this.Table().SendKeys(Keys.PageUp);
					//if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
					//{
					//	break;
					//}
					//this.Table().SendKeys(Keys.PageUp);
					//if (calendarButton.TryClick() && this.CalenderDatePickerDisplayed(state))
					//{
					//	break;
					//}
					Report.Info("Failed to click the calender button.Trying again...");
					if (state == "NY")
					{
						Report.Info("Attempting to access the NY calendar button by scolling the page down again");
						new Actions(SeleniumWebDriver.CurrentDriver).SendKeys(Keys.ArrowDown).Perform();
						if (calendarButton.TryClick())
						{
							break;
						}

					}


					attempt++;
				}
				catch (Exception)
				{

				}
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
			if (!this.GetCalendarActiveDate(out string startMonth, out string startYear))
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
			int activeYear = int.Parse(startYear);
			int activeMonth = DateTime.ParseExact(startMonth, "MMMM", CultureInfo.CurrentCulture).Month;
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
				SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//th[@class='next']"), 2).TryClick();
				//activeDate = this.CalendarActiveDate();
				if (!this.GetCalendarActiveDate(out string month, out string year))
				{
					Report.Failure("Failed to get active date from calendar date selector!");
					Report.Screenshot();
					return false;
				}
				activeYear = int.Parse(year);
				activeMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
			}
			// Select day
			return SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]//td[@class='day' and text()='" + date.Day + "']"), 2).TryClick();
		}

		public bool GetCalendarActiveDate(out string month, out string year)
		{
			IWebElement calendarTable = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(".//table[parent::div[@class='datepicker-days']]"), 2);
			IWebElement datePicker = calendarTable?.FindElement(By.XPath(".//th[@class='datepicker-switch']"), 2);
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
			IWebElement epaRow = this.Table().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
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
			string colourCode = epaRow.GetAttribute("class");
			return colourCode?.Replace("rpds-", "");
		}

		public string TableRowBackgroundHex(string state)
		{
			IWebElement epaRow = this.Table().FindElement(By.XPath(".//tr[.//div[text()='" + state + "']]"), 2);
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
			IWebElement epaTable = this.Table();
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
			List<string> headings = this.TableColumnHeadings();
			if (!expectedHeadings.All(x => headings.Contains(x)))
			{
				Report.Error("The table headings did not match those expected! => " + string.Join(", ", expectedHeadings));
				Report.Screenshot();
				return null;
			}
			var rows = epaTable.FindElements(By.XPath(".//tbody/tr"), 2).ToList();
			Report.Info("Getting state data for: " + rows.Count + " rows");
			foreach (IWebElement thisRow in rows)
			{
				string state = thisRow.FindElement(By.XPath($".//td[position() = {headings.IndexOf(expectedHeadings[1]) + 1}]//div"), 2).Text;
				string expirationDate = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[2]) + 1}]//input"), 2).GetValue();
				IWebElement registrationNumberEl = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[0]) + 1}]//input"), 2);
				string registrationNumber = registrationNumberEl.GetValue();
				if (registrationNumber.Length == 0)
				{
					registrationNumber = registrationNumberEl.GetAttribute("placeholder");
				}
				string kellyDate = thisRow.FindElement(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[3]) + 1}]//label"), 2)?.Text;
				bool isKellyData = thisRow.FindElements(By.XPath($".//td[position()={headings.IndexOf(expectedHeadings[4]) + 1}]//div"), 2).Count == 1;
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


		public bool CheckIfThereIsNoErrorInThePesticideDetailsStateRegistration()
		{
			IList<IWebElement> error = this.containerElement.FindElements(By.XPath("//div[@class='alert alert-danger']//p[@class='form-error']"), 2);
			if (error.Count < 1)
			{
				return true;
			}

			return false;
		}



		public bool EnterExpirationDateForStatePesticideReigstration(string date, string state)
		{
			IWebElement calendar = this.containerElement.FindElement(By.XPath("//div[text()='" + state + "']/../following-sibling::td//input[@data-date-format=\"yyyy-mm-dd\"]"), 2);
			return calendar.TryEnterText(date);
		}
		public bool EnterEpaPesticideRegistrationNo(string enterText)
		{
			IWebElement textField = this.containerElement.FindElement(By.XPath("//th[text()='EPA Pesticide Registration No.']/../../following-sibling::tbody//input"), 2);
			return textField.TryEnterText(enterText);
		}

		public bool ClickxForRegistrationDetailsForState(string abbrevState)
		{
			IWebElement xButton = this.containerElement.FindElement(By.XPath("//div[@data-bind='html: field.field'][text()='" + abbrevState + "']/../following-sibling::td//a"), 2);
			if (xButton == null)
			{
				return false;
			}
			return xButton.TryClick();
		}
		public bool ClickYesOrNoForRegistrationDetailsRemoveItemPopup(string yesOrNo)
		{
			IWebElement yesOrNoButton = this.containerElement.FindElement(By.XPath("//h3[@class='modal-title'][text()='Remove Item']/../..//div[@class='modal-footer']//button[text()='" + yesOrNo + "']"), 2);
			if (yesOrNoButton == null)
			{
				return false;
			}
			return yesOrNoButton.TryClick();
		}

	}
	class PesticideDetailsStateRegistrationRow : SeleniumBaseObject
	{
		public string state;
		public PesticideDetailsStateRegistrationRow(string state)
		{
			this.state = state;
		}
		protected override By ContainerElementLocator => By.XPath($".//tr[td//div[text() = '{this.state}']]");
		public bool EnterStatus(string status)
		{
			Report.Info($"Attempt to select status {status} for state {this.state}");
			IWebElement Status = this.ContainerElement.FindElement(By.XPath($".//span[text() = '{status}']"));
			Status.ScrollToElement();
			return Status.TryClick();
		}
		public bool EnterDate(string date)
		{
			bool result = false;
			var pesticideDetailsStateRegistrationTable = new PesticideDetailsStateRegistrationTable();
			Report.Info($"Attempt to enter date {date} for state {this.state}");
			IWebElement Date = this.ContainerElement.FindElement(By.XPath(".//td//input[@type = 'text']"));
			if (Date != null)
			{
				Date.ScrollToElement();
				result = Date.TryEnterText(date);
				if (result == true)
				{
					pesticideDetailsStateRegistrationTable.ClickActiveDay();
				}
			}
			else
			{
				Report.Info("Cannot find State Expiration Date input");
			}
			return result;
		}
		public bool DateIsPrefilled(string status)
		{
			string getDate;
			Report.Info($"Attempt to verify State Expiration Date is prefilled for state {state}");
			bool result = false;
			IWebElement Date = this.ContainerElement.FindElement(By.XPath(".//td//input[@type = 'text']"));
			Date.ScrollToElement();
			getDate = Date.GetValue();
			if (getDate.Length > 0 && getDate != null)
			{
				Report.Info($"Prefilled date is {getDate}");
				result = true;
			}
			return result;
		}
		public bool SelectedStatusForState(string status)
		{
			Report.Info($"Attempt to verify {status} status is selected for state {this.state}");
			IWebElement Status = this.ContainerElement.FindElement(By.XPath($".//div//label[span[text() = '{status}']]//input"));
			Status.ScrollToElement();
			return Status.Selected;
		}
		public bool ColorHighlighting(string days)
		{
			bool result = false;
			string colorAttribute;
			Report.Info($"Attempt to verify row color highlighting indicates item is expiring in less then {days} for state {state}");
			this.ContainerElement.ScrollToElement();
			colorAttribute = this.ContainerElement.GetAttribute("class");
			switch (days)
			{
				case "90":
					if (colorAttribute == "rpds-rowcolor-1")
					{
						result = true;
					}
					break;
				case "31":
					if (colorAttribute == "rpds-rowcolor-2")
					{
						result = true;
					}
					break;
			}
			return result;
		}
		public bool VerifyExpirationImportedMark()
		{
			Report.Info($"Attempt to verify check mark is displayed for state {this.state}");
			IWebElement CheckMark = this.ContainerElement.FindElement(By.XPath($".//div[@class='fa fa-check']"));
			CheckMark.ScrollToElement();
			return CheckMark.Displayed;
		}

	}
	class PesticideDetailsStateRegistrationTable : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//table[@class = 'table table-hover table-fixed']");
		List<IWebElement> Rows => this.ContainerElement.FindElements(By.XPath(".//tbody//tr")).ToList();
		List<IWebElement> StatusRadioButtons => this.ContainerElement.FindElements(By.XPath(".//tr[td//div[text() = 'AK']]//td[div//input[@type = 'radio']]")).ToList();
		List<IWebElement> SelectAllRadioButtons => this.ContainerElement.FindElements(By.XPath("//td[div//span[text() = 'Select All']]//input")).ToList();

		private IWebElement ActiveDay => this.ContainerElement.FindElement(By.XPath("//td[@class = 'active day']"));

		public bool ClickActiveDay()
		{
			return this.ActiveDay.TryClick();
		}

		public bool SelectOneStatusForAllStatesWithNoSelectedStatus(string status)
		{
			bool result = true;
			string getState;
			foreach (IWebElement row in this.Rows)
			{
				IWebElement State = row.FindElement(By.XPath($".//td//div"));
				getState = State.Text;
				bool statusIsSelected = new PesticideDetailsStateRegistrationRow(getState).SelectedStatusForState("Registered");
				if (!new PesticideDetailsStateRegistrationRow(getState).VerifyExpirationImportedMark())
				{
					if (!State.VisibleInViewport())
					{
						State.ScrollToElement();
					}
					if (!new PesticideDetailsStateRegistrationRow(getState).EnterStatus(status))
					{
						Report.Failure($"Failed to selest status {status} for state {getState}");
						result = false;
					}
				}
			}
			return result;
		}

		public bool ClickSelectAllForStatus(string status)
		{
			bool result = false;
			string getStatus;
			int i = 0;
			foreach (IWebElement statusRadio in this.StatusRadioButtons)
			{
				getStatus = statusRadio.Text;
				if (getStatus == status)
				{
					result = this.SelectAllRadioButtons[i].TryClick();
					break;
				}
				i++;
			}
			return result;
		}
	}
	public static class ScrollFunction
	{
		public static void ScrollToElement(this IWebElement element)
		{
			int x = element.Location.X;
			int y = element.Location.Y;
			(element.GetWebDriver() as IJavaScriptExecutor).ExecuteScript("scroll(arguments[0], arguments[1]);", x, y);
			Delay.Seconds(1.0);
		}
	}


}

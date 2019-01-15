using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using ResourcePool;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes.New_Product;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_PesticideDetailsState
	{
		[StepDefinition(@"in page Pesticide Details - State Registration Details I should see error: (.*)")]
		public void IShouldSeeError(string error)
		{
			var thisNewProduct = new NewProduct();
			var erros = thisNewProduct.AllErrorMessages();
			Report.IsTrue(erros.Contains(error), "Expected error: " + error + " but got: " + string.Join(", ", erros),
				"As expected, error is showing as: " + error);
		}

		[StepDefinition(@"in page Pesticide Details - State Registration Details I should see no errors")]
		public void IShouldSeeNoError()
		{
			var thisNewProduct = new NewProduct();
			var erros = thisNewProduct.AllErrorMessages();
			Report.IsTrue(!erros.Any(), "Expected no errors but there were errors!",
				"There were no errors as expected");
		}

		[StepDefinition(@"I should see the appropriate response depending on today's date for state: (.*)")]
		public void ThenIShouldSeeTheAppropriateResponseDependingOnTodaySDateforstate(string state)
		{
			var stepsNewProduct = new StepsNewProduct();
			var year = DateTime.Now.Year;
			var Oct1stthisYear = new DateTime(year, 10, 1);
			if (DateTime.Now < Oct1stthisYear)
			{
				this.IShouldSeeError("State " + state + ": Valid dates are December 31 of current calendar year until October 1, at which time December 31 of either the current or the following calendar year would be acceptable.");
			}
			else
			{
				//If the current date is > Oct 1st confirm the Transportation Details 1 step is shown and Click the Pesticide Details -State Registration Details heading
				stepsNewProduct.GivenIShouldSeeXPage("Transportation Details 1");
				stepsNewProduct.GivenInTheNewProductPageIClickSection("Pesticide Details - State Registration Details");
			}
		}

		[StepDefinition(@"I edit the Expiration Date to: (.*) for the State: (.*) on the Pesticide State Registration Details page")]
		public void IEnterAnExpirationDateForPesticideStateRegistration(string expirationDate, string state)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			Context.AddToContext("state", state);
			var dateRegex = new Regex(@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$");
			if (!dateRegex.IsMatch(expirationDate))
			{
				Report.Failure("The format of the provided date text was incorrect. Enter a date like: 'YYYY-MM-DD'");
				Report.Screenshot();
			}
			if (state.Length != 2)
			{
				Report.Failure("The state text provided was incorrect. Enter a state like: 'AZ', 'CO' etc.");
				Report.Screenshot();
			}
			Report.IsTrue(pesticideDetailsState.EditExpirationDate(expirationDate, state),
				$"The Pesticide Registration Expiration Date for state '{state}' was not successfully edited to be '{expirationDate}'",
				$"The Pesticide Registration Expiration Date for state '{state}' was successfully edited to be '{expirationDate}'");
		}

		[StepDefinition(@"I confirm the Expiration Date matches the value provided by Kelly on the State Registration Details Page for the edited State")]
		public void IConfirmTheExpirationDateMatchesTheKellyValue()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			if (!ScenarioContext.Current.ContainsKey("state"))
			{
				throw new Exception("There was no State text in the scenario context. Check the pre-requisite step for editing Expiration Date has ran successfully.");
			}
			var state = Context.GetFromContext("state").ToString();
			var expirationDate = pesticideDetailsState.ExpirationDate(state);
			var kellyExpirationDate = pesticideDetailsState.GetPesticideRegKellyExpirationDate(state);
			Report.IsTrue(expirationDate == kellyExpirationDate, "The Expiration Date does not match the value provided by Kelly", "The Expiration correctly matches the value provided by Kelly");
		}

		[StepDefinition(@"I click the Update Wercs Smart data with EPA data through Kelly Services link")]
		public void IClickTheUpdateWercsSmartDataThroughKellyServicesLink()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsState.ClickEpaKellyServicesLink(), "Failed to click the EPA Kelly Services link on the Pesticide State Registration Details page", "Successfully clicked the EPA Kelly Services link on the Pesticide State Registration Details page");
		}

		[StepDefinition(@"I edit each State Pesticide Registration Number with an edited suffix")]
		public void IEditEachStatePesticideRegNumberWithSuffix()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var rowCount = pesticideDetailsState.StateRowsCount();
			var notEdited = new List<string>();
			for (var i = 0; i < rowCount; i++)
			{
				if (!pesticideDetailsState.AddSuffixToPesticideRegistrationNumber(i))
				{
					notEdited.Add((i + 1).ToString());
				}
			}
			Report.IsTrue(notEdited.Count == 0,
				"The State Pesticide Registration Number for the following rows was not successfully edited: " + string.Join(", ", notEdited),
				"Every State Pesticide Registrtaion Number in the table was successfully edited");
		}

		[StepDefinition(@"I check each State Pesticide Registration Number contains the edited suffix")]
		public void ICheckEachStatePesticideRegNumberContains()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var rowCount = pesticideDetailsState.StateRowsCount();
			if (rowCount == -1)
			{
				Report.Failure("Failed to count State Registration Details table rows due to null element!");
				return;
			}
			var notEdited = new List<string>();
			for (var i = 0; i < rowCount; i++)
			{
				if (pesticideDetailsState.StatePesticideRegistrationNumberIsEdited(i))
				{
					continue;
				}
				Report.Screenshot();
				notEdited.Add(i + 1.ToString());
			}
			Report.IsTrue(notEdited.Count == 0,
				"The State Pesticide Registration Number for the following rows was not successfully edited: " + string.Join(", ", notEdited),
				"Every State Pesticide Registrtaion Number in the table was successfully edited");
		}

		[StepDefinition(@"I confirm that there is data populated in the Expiration Date Column for some States")]
		public void IConfirmDataInExpirationDateColumnPesticideStates()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var rowCount = pesticideDetailsState.StateRowsCount();
			var expirationDateIndexes = new List<int>();
			Report.Screenshot();
			for (var i = 0; i < rowCount; i++)
			{
				if (!pesticideDetailsState.StateRowHasExpirationDate(i))
				{
					continue;
				}
				var rowNumber = i + 1;
				Report.Info("State at row number: " + rowNumber + " contained an Expiration Date");
				expirationDateIndexes.Add(i);
			}
			Report.IsTrue(expirationDateIndexes.Count > 0,
				"No States were found to contain data for Expiration Date on the Pesticide State Registration Details page",
				"Some States contained data in Expiration Date column as expected");
			// We add the indexes as a list to the scenario context to allow checking the 'Is Kelly Data Data' field in another step
			Context.AddToContext("Expiration Date Indexes", expirationDateIndexes);
		}

		[StepDefinition(@"I confirm the 'Is Kelly Data' field is marked with a check for every State containing data in 'Expiration Date'")]
		public void IConfirmKellyDataFieldIsCheckedWhenExpirationDateExists()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var rowsToCheck = new List<int>();
			if (ScenarioContext.Current.ContainsKey("Expiration Date Indexes"))
			{
				rowsToCheck = (List<int>)Context.GetFromContext("Expiration Date Indexes");
				foreach (var index in rowsToCheck)
				{
					if (!pesticideDetailsState.KellyDataIsTicked(index))
					{
						Report.Failure("The State at row index: " + index + " did not contain a check mark under the Is Kelly Data column as expected");
						return;
					}
				}
				Report.Success("All States with an Expiration Date also had a check mark under the 'Is Kelly Data' column as expceted");
				Report.Screenshot();
			}
			else
			{
				Report.Failure("There were no States to check the Kelly Data field (rows containing an Expiration Date)");
				Report.Screenshot();
			}
		}

		[StepDefinition(@"I confirm the Expiration Date Provided By Kelly field for state: (.*) is blank")]
		public void IConfirmTheExpirationDateProvidedByKellyForStateIsBlank(string currentState)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var state = "";
			if (ScenarioContext.Current.ContainsKey("state"))
			{
				state = Context.GetFromContext("state").ToString();
				Report.Info("Looking at state from test context: " + state);
			}
			else
			{
				state = currentState;
				Report.Info("Looking at state from test definition: " + state);
			}
			Report.IsTrue(pesticideDetailsState.GetPesticideRegKellyExpirationDate(state).IsNullOrEmpty(),
				"The Expiration Date Provided By Kelly field for state " + state + " was not blank when it was expected to be.",
				"The Expiration Date Provided By Kelly field for state: " + state + " was blank as expected");
		}

		[StepDefinition(@"I confirm the 'Is Kelly Data' field for State: (.*) (is|is not) checked")]
		public void IConfirmKellyDataIsOrIsNotChecked(string state, string check)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			if (state.Length != 2)
			{
				Report.Warn("Expecting a state provided in the form: AZ, IL, NY etc.");
			}
			if (check == "is")
			{
				Report.IsTrue(pesticideDetailsState.KellyDataIsTicked(state), "The 'Is Kelly Data' field for State : " + state + " didn't contain a check when it was expected to", "The 'Is Kelly Data' field for State: " + state + " contained a check as expected");
				return;
			}
			if (check == "is not")
			{
				Report.IsFalse(pesticideDetailsState.KellyDataIsTicked(state), "The 'Is Kelly Data' field for State: " + state + " contained a check when it should not", "The 'Is Kelly Data' field for State: " + state + " did not contain a check as expected");
				return;
			}
			Report.Failure("Invalid step parameter! Must be either 'is' or 'is not'");
		}

		[StepDefinition(@"I confirm the Expiration Date field for state: (.*) is showing the value: (.*)")]
		public void ExpirationDateForStateIsShowingValue(string state, string date)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var actualDate = pesticideDetailsState.ExpirationDate(state);
			Report.IsTrue(actualDate == date,
				$"The Expiration Date field for State: '{state}' was not showing the value: '{date}' as expected. It was showing the value: '{actualDate}'",
				$"The Expiration Date field for State: '{state}' was showing the value: '{date}' as expected");
		}

		[StepDefinition(@"I confirm that every date in the Expiration Date column has a matching date in the Expiration Date provided by Kelly column")]
		public void ThenIConfirmThatEveryDateInTheExpirationDateColumnHasAMatchingDateInTheExpirationDateProvidedByKellyColumn()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var AllPesticideDetails = pesticideDetailsState.GetStatePesticideRegistrationDetails();

			foreach (PesticideDetailsState.StatePesticideRegistration thisRow in AllPesticideDetails)
			{
				if (thisRow.ExpirationDate.Length > 0)
				{
					Report.IsTrue(thisRow.ExpirationDate == thisRow.ExpirationDateByKelly,
						"For state: " + thisRow.State + "Expiration date: " + thisRow.ExpirationDate +
						" does not match Kelly expiration date: " + thisRow.ExpirationDateByKelly,
						"As expected, for state: " + thisRow.State +
						" Expiration date and Kelly Expiration date are matching on: " + thisRow.ExpirationDate);
				}
			}
		}

		[StepDefinition(@"I check the State Pesticide Registration Number field matches the text: (.*)")]
		public void CheckStatePesticideRegistrationNumber(string regNumText)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var stateRegistrationData = pesticideDetailsState.GetStatePesticideRegistrationDetails();
			var failReg = stateRegistrationData.FirstOrDefault(x => x.RegistrationNumber.Trim() != regNumText.Trim());
			var failState = failReg == null ? "N/A" : failReg.State;
			Report.IsTrue(failReg == null,
				"The State Pesticide Registration Number column did not match the expected text: " + regNumText + ". Failed on state: " + failState,
				"The State Pesticide Registration Number column matched the expected text: " + regNumText);
		}

		[StepDefinition(@"I confirm the State Registration EPA table does not contain any Expiration data")]
		public void ConfirmExpirationDataBlankInStateEPATable()
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var epaData = pesticideDetailsState.GetStatePesticideRegistrationDetails();
			var failReg = epaData.FirstOrDefault(x => !x.ExpirationDate.IsNullOrEmpty()) ?? epaData.FirstOrDefault(x => !x.ExpirationDateByKelly.IsNullOrEmpty());
			var failState = failReg == null ? "N/A" : failReg.State;
			Report.IsTrue(failReg == null,
				"The State Registration EPA table contained Expiration data when it was not expected. Broke on state: " + failState,
				"The State Registration EPA table did not contain any Expiration data as expected");
		}

		[StepDefinition(@"If the current date is after \(MM/DD\): (.*)/(.*) then I confirm no error is shown for the State: (.*) - else I confirm the following error is displayed: (.*)")]
		public void ConfirmNovemberErrorBasedOnCurrentDate(string month, string day, string state, string error)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			var year = DateTime.Now.Year;
			DateTime comparisonDate;
			if (int.TryParse(month, out int monthNum) && int.TryParse(day, out int dayNum))
			{
				comparisonDate = new DateTime(year, monthNum, dayNum);
			}
			else
			{
				throw new Exception("Day/ month parameter must be parsable as an int!");
			}
			var currentDate = DateTime.Now;
			Report.Info("Current date (DD/MM/YY) is: " + currentDate.Date + "/" + currentDate.Month + "/" + currentDate.Year);
			if (DateTime.Now < comparisonDate)
			{
				Report.Info("Date is prior to Sept 1st. I expect to see the state error");
				this.IShouldSeeError("State " + state + ": Valid dates are November 30 of current calendar year until September 1, at which time November 30 of either the current or the following calendar year would be acceptable.");
			}
			else
			{
				Report.Info("Date is post Sept 1st. I expect no state error");
				this.IShouldSeeNoError();
			}
		}


		[StepDefinition(@"If the current date is after \(MM/DD\): (.*)/(.*) then I confirm the error is displayed: 'The expiration date must be a valid future date' - else I confirm that no error is shown and the '(.*)' page has loaded")]
		public void IfCurrentDateExceedsEpaDateConfirmError(string month, string day, string page)
		{
			var year = DateTime.Now.Year;
			DateTime comparisonDate;
			if (int.TryParse(month, out int monthNum) && int.TryParse(day, out int dayNum))
			{
				comparisonDate = new DateTime(year, monthNum, dayNum);
			}
			else
			{
				throw new Exception("Day/ month parameter must be parsable as an int!");
			}
			var currentDate = DateTime.Now;
			Report.Info("Current date (DD/MM/YY) is: " + currentDate.Date + "/" + currentDate.Month + "/" + currentDate.Year);
			if (DateTime.Now < comparisonDate)
			{

				Report.Info("Current date is prior to the expiration date. I expect no state error");
				this.IShouldSeeNoError();
				new StepsNewProduct().GivenIShouldSeeXPage(page);
			}
			else
			{
				Report.Info("Current date has passed expiration date. I expect to see the state error");
				this.IShouldSeeError("The expiration date must be a valid future date");

			}
		}

		[StepDefinition(@"I enter the EPA registration date in the current year:")]
		public void EnterEpaRegistrationDateCurrentYear(Table table)
		{
			//'increment year?' set to yes or no depending on whether you want to +1 to the year if the current date is later than the reg date input (which causes an error, as stated by tests)
			// | State | Day | Month | Increment year?			|
			// | NY    | 01  | 01    | yes						|
			foreach (var row in table.Rows)
			{
				var month = row["Month"];
				var day = row["Day"];
				var state = row["State"];
				var useNextYear = row["Increment year?"];
				bool iterateYear;
				if (useNextYear.ToLower() == "yes" || useNextYear.ToLower() == "true")
				{
					Report.Info("Using next year if the current date > target date.");
					iterateYear = true;
				}
				else if (useNextYear.ToLower() == "no" || useNextYear.ToLower() == "false")
				{
					Report.Info("Using the current year regardless of the current date.");
					iterateYear = false;
				}
				else
				{
					throw new Exception("'Use Next Year' parameter did not match expected text (yes/ no OR true/ false)");
				}
				var pesticideDetailsState = new PesticideDetailsState();
				TestReport.UseSubSteps = true;
				TestReport.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
				var year = DateTime.Now.Year;
				if (int.TryParse(month, out var monthNum) && int.TryParse(day, out var dateNum))
				{
					Report.Info("From test plan: 'If the current date is after XX xxth for the current year select XX xxth for next year'");
					var dt = new DateTime(year, monthNum, dateNum);
					if (dt < DateTime.Now && iterateYear)
					{
						Report.Info("Using the next year because the current date has passed the specified date");
						dt = new DateTime(year + 1, monthNum, dateNum);
					}
					Report.Info("Entering date of (month/date): " + dt.Month + "/ " + dt.Day + " (NOT Nov 30)");
					Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
						"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
						"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
					// Click Continue
					//TestReport.StartStep("I click continue in the Pesticide Details - State Registration page");
					//new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Pesticide Details - State Registration Details");
				}
				else
				{
					throw new Exception("Month/ date parameter must be parsable as an integer!");
				}

			}

		}

		[StepDefinition(@"I enter the EPA registration date in the next year for state: (.*):")]
		public void EnterEpaRegistrationDateNextYear(string month, string date, string state)
		{
			var pesticideDetailsState = new PesticideDetailsState();
			TestReport.UseSubSteps = true;
			TestReport.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
			var year = DateTime.Now.Year;
			if (int.TryParse(month, out var monthNum) && int.TryParse(date, out var dateNum))
			{
				Report.Info("From test plan: 'If the current date is after XX xxth for the current year select XX xxth for next year + 1'");
				var dt = new DateTime(year, monthNum, dateNum);
				if (dt < DateTime.Now)
				{
					Report.Info("Using the next year + 1 because the current date has passed the specified date");
					dt = new DateTime(year + 2, monthNum, dateNum);
				}
				else
				{
					Report.Info("Using the next year for EPA registration");
					dt = new DateTime(year + 1, monthNum, dateNum);
				}
				Report.Info("Entering date of (month/date): " + dt.Month + "/ " + dt.Day + " (NOT Nov 30)");
				Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
					"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
					"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
				// Click Continue
				TestReport.StartStep("I click continue in the Pesticide Details - State Registration page");
				new StepsNewProduct().GivenInTheNewProductPageIClickContinue("Pesticide Details - State Registration Details");
			}
			else
			{
				throw new Exception("Month/ date parameter must be parsable as an integer!");
			}
		}

		[StepDefinition(@"I select expiration date \(current year - Not August 31st\) for state: (.*)")]
		public void ExpirationDate_CurrentYear_NotAugust31th(string state)
		{
			var table = new Table("State", "Month", "Day", "Increment year?");
			table.AddRow(state,"8", "1", "no");
			this.EnterEpaRegistrationDateCurrentYear(table);
		}

		[StepDefinition(@"I select expiration date \(next year - Not August 31st\) for state: (.*)")]
		public void ExpirationDate_NextYear_NotAugust31th(string state)
		{
			this.EnterEpaRegistrationDateNextYear("8", "1", state);
		}

		[StepDefinition(@"I select EPA expiration date - enter current year plus 2:")]
		public void SharedStep_EPAExpirationDate_EnterCurrentYearPlus2(Table table)
		{
			// Click in the EPA Expiration Date box for the state you are working with
			// Select EPA day/ month for the current year + 2
			// | State | Day | Month |
			// | NY    | 01  | 01    |
			foreach (var row in table.Rows)
			{
				var day = row["Day"];
				var month = row["Month"];
				var state = row["State"];
				var pesticideDetailsState = new PesticideDetailsState();
				TestReport.UseSubSteps = true;
				TestReport.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
				var MyStepsNewProduct = new StepsNewProduct();
				var year = DateTime.Now.Year + 2;
				DateTime dt;
				if (int.TryParse(month, out int monthNum) && int.TryParse(day, out int dayNum))
				{
					 dt = new DateTime(year, monthNum, dayNum);
				}
				else
				{
					throw new Exception("Day/ month paramaters must be parsable as int!");
				}
				Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
					"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
					"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			}

		}

		// enter 'NONE' or 'N/A' if no error is excepted
		[StepDefinition(@"If the (current|next) year is an (even|odd) number - Confirm that an error shows: (.*)")]
		public void IfCurrentYearIsEvenOddConfirmError(string currentNext, string evenOdd, string error)
		{
			if (evenOdd != "even" && evenOdd != "odd")
			{
				throw new Exception("Step parameter must be either 'even' or 'odd'!");
			}
			int year;
			switch (currentNext.ToLower())
			{
				case "next":
					year = DateTime.Now.Year + 1;
					break;
				case "current":
					year = DateTime.Now.Year;
					break;
				default:
					throw new Exception("Step parameter must be either 'current' or 'next'!");
			}
			if ((evenOdd == "even") == (year % 2 == 0))
			{
				Report.Info("The year: " + year + " is " + (year % 2 == 0 ? "even" : "odd"));
				if (error.ToLower() == "none" || error.ToLower() == "n/a")
				{
					Report.Info("I don't expect any state error");
					this.IShouldSeeNoError();
				}
				else
				{
					Report.Info("I expect to see the state error");
					this.IShouldSeeError(error);
				}
			}
			else
			{
				Report.Info("The year" + year + " is: " + (evenOdd == "even" ? "odd" : "even"));
			}
		}

		[StepDefinition(@"If the current year is an (even|odd) number I confirm that no error is displayed and the '(.*)' page has loaded")]
		public void IfCurrentYearIsOddIConfirmNoErrorAndPageLoaded(string evenOdd, string page)
		{
			if (evenOdd != "even" && evenOdd != "odd")
			{
				throw new Exception("Step parameter must be either 'even' or 'odd'!");
			}
			var year = DateTime.Now.Year;
			if ((evenOdd == "even") == (year % 2 == 0))
			{
				this.IShouldSeeNoError();
				new StepsNewProduct().GivenIShouldSeeXPage(page);
			}
			else
			{
				Report.Info("The current year " + year + " is an " + (evenOdd == "even" ? "odd" : "even") + " number");
			}
		}

		[StepDefinition(@"I select EPA expiration date - enter current year plus 3:")]
		public void SharedStep_EPAExpirationDate_EnterCurrentYearPlus3(Table table)
		{
			// Click in the EPA Expiration Date box for the state you are working with
			// Select EPA day/ month for the current year + 2
			// | State | Day | Month |
			// | NY    | 01  | 01    |
			foreach (var row in table.Rows)
			{
				var day = row["Day"];
				var month = row["Month"];
				var state = row["State"];
				var pesticideDetailsState = new PesticideDetailsState();
				TestReport.UseSubSteps = true;
				TestReport.StartStep("I click the EPA Expiration Date box for the state: " + state + " and select a date for the current year that is not June 30th");
				var MyStepsNewProduct = new StepsNewProduct();
				var year = DateTime.Now.Year + 3;
				DateTime dt;
				if (int.TryParse(month, out int monthNum) && int.TryParse(day, out int dayNum))
				{
					dt = new DateTime(year, monthNum, dayNum);
				}
				else
				{
					throw new Exception("Day/ month paramaters must be parsable as int!");
				}
				Report.IsTrue(pesticideDetailsState.EditExpirationDate(dt.ToString("yyyy-MM-dd"), state),
					"Failed to enter date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state,
					"Successfully entered date: " + dt.ToString("yyyy-MM-dd") + " for state: " + state);
			}

		}
	}
}

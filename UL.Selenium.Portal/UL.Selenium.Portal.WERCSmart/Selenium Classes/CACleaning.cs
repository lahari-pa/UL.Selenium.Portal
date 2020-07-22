using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class CACleaning
	{
		public bool SelectXForComponentNumber(string number)
		{
			IList<IWebElement> xButtons = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//a[@aria-label='Delete component']"), 2);
			int numberInt = int.Parse(number);
			return xButtons[numberInt - 1].TryClick();
		}

		public bool ConfirmTruckIconIsDisplayedForUPC(string savedAs)
		{
			IWebElement truckIcon = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']/following-sibling::i"), 2);
			if (truckIcon != null)
			{
				return true;
			}

			return false;
		}

		public bool CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(string text)
		{
			IWebElement alertMessage1 = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='alert alert-info alert-dismissible']//label//input"), 2);
			return alertMessage1.TryCheck();
		}

		public bool CloseCACleaningIngredientsPopupWindow()
		{
			IWebElement closeButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div/following-sibling::div//button"), 2);
			return closeButton.TryClick();
		}
		public bool CheckForTwoErrorMessagesInPopupWithTitle(Table table, string popupTitle)
		{
			List<string> errors = new List<string>();

			foreach (TableRow row in table.Rows)
			{
				if (row["Error"] == "Generic")
				{
					errors.Add("GenericInUse");
				}
				else if (row["Error"] == "Percent")
				{
					errors.Add("LessThan100Percent");
				}
				else if (row["Error"] == "Publicly Disclosed or Trade Secret")
				{
					errors.Add("PublicDisclosureOrTradeSecretIssue");
				}
				else if (row["Error"] == "Ingredient Type")
				{
					errors.Add("IngredientTypeMissing");
				}
				else if (row["Error"] == "Functional Purpose")
				{
					errors.Add("FragranceComponentFunctionalPurposeMismatch");
				}
				else if (row["Error"] == "Publicly Disclosed")
				{
					errors.Add("NonFunctionalIngredientDisclosureIssue");
				}
				else if (row["Error"] == "Public Name")
				{
					errors.Add("CAHCPPublicDisclosureIssues");
				}
				else if (row["Error"] == "Ingredient Type with Functional Purpose")
				{
					errors.Add("NonFunctionalIngredientTypeOrFunctionalPurposeMismatch");
				}
				else if (row["Error"] == "Third Party")
				{
					errors.Add("PVBOTThirdPartyError");
				}
				else
				{
					return false;
				}
			}

			foreach (string error in errors)
			{
				IWebElement errorEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[@data-bind='visible: model." + error + "'][@style='display: none;']"), 2);
				if (errorEl != null)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckForErrorMessagesInPopupWithTitle(string popupTitle)
		{
			IList<IWebElement> errorMessages = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div"), 2);
			if (errorMessages[1].Text.Contains("Generic ingredients are not permitted as they cannot be screened for Chemicals of Concern. Each ingredient must use any of the following: Valid Chemical Abstract Service identifier(CAS number); or Valid 3rd - Party Formula registration(CAS begins with \"WPS\"); or Valid CAS Addition(CAS begins with NA) Please note that use of an ingredient with a CAS beginning with NA may result in a suspension of the registration requiring more information or details. You should always use a valid CAS number or 3rd - Party Formula before using an NA option."))
			{
				Report.Info("true");
			}
			else
			{
				Report.Info("false " + errorMessages[1].Text);
				Report.Info("false " + errorMessages[2].Text);
				Report.Info("false " + errorMessages[3].Text);
				Report.Info("false " + errorMessages[4].Text);
			}
			return true;
		}

		public bool CheckForMessageAtTheTopOfIngredientsPage()
		{
			IWebElement alertMessage = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='alert alert-info alert-dismissible']"), 2);
			if (alertMessage.Text.Contains("Note: there are special requirements for formulations that must be met in order to generate a California Cleaning Right to Know ingredient disclosure report. Formulations CANNOT contain:")
				&& alertMessage.Text.Contains("Any generic ingredient names (e.g., fragrance). Each generic ingredient name must be replaced by either a registered 3rd-Party component, or a list of the specific ingredients that comprise the generic mixture.")
				&& alertMessage.Text.Contains("An indication of the ingredient being EITHER \"Publicly Disclosed\" or \"Trade Secret\".")
				&& alertMessage.Text.Contains("For each Publicly Disclosed ingredient, select a Public Name.")
				&& alertMessage.Text.Contains("For each Trade Secret ingredient, provide a public name that is only as generic as necessary to protect its confidential identity."))
			{
				return true;
			}

			return false;
		}

		public bool ClickCloseInPopupWithTitle(string title)
		{
			IWebElement continueButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='" + title + "']/../following-sibling::div[@class='modal-footer']//button"), 2);
			return continueButton.TryClick();
		}
		public bool CheckDeleteRowsWarningPopupContainsText(string lineOne, string lineTwo)
		{
			IWebElement lineOneEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[1]"), 2);
			IWebElement lineTwoEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='Warning!']/../..//div[@class='modal-body']//p[2]"), 2);

			if (lineOneEl.Text == lineOne && lineTwoEl.Text == lineTwo)
			{
				return true;
			}

			return false;
		}
	}
}

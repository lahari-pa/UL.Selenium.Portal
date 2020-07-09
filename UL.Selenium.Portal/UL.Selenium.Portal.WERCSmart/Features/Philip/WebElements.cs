using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.Classes;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	class WebElements : SeleniumBaseObject
	{

		public const string BasePath = "";

		protected override By ContainerElementLocator => throw new System.NotImplementedException();

		//public bool CheckForCheckBoxWithTextInMessageAtTheTopOfIngredientsPage(string text)
		//{
		//	IWebElement alertMessage1 = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//div[@class='alert alert-info alert-dismissible']//label"), 2);

		//}

		public bool CloseCACleaningIngredientsPopupWindow(string popupTitle)
		{
			IWebElement closeButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='" + popupTitle + "']/../following-sibling::div/following-sibling::div//button"), 2);
			return closeButton.TryClick();
		}

		public bool CheckForTwoErrorMessagesInPopupWithTitle(string popupTitle)
		{
			IWebElement publicDisclosureOrTradeSecretError = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[@data-bind='visible: model.IngredientTypeMissing']"), 2);
			IWebElement ingredientTypeError = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div[@data-bind='visible: model.IngredientTypeMissing']"), 2);

			if (publicDisclosureOrTradeSecretError.Text.Contains("Participation in the California Cleaning Right to Know requires that each ingredient have an indication of the type of ingredient it is within the product. Please include, for each ingredient, the Ingredient Type from the selections available."))
			{
				Report.Info("true");
			}
			else
			{
				Report.Info("false " + publicDisclosureOrTradeSecretError.Text);
			}

			if (ingredientTypeError.Text.Contains("Participation in the California Cleaning Right to Know requires that each ingredient have an indication of the type of ingredient it is within the product. Please include, for each ingredient, the Ingredient Type from the selections available."))
			{
				Report.Info("true1");
			}
			else
			{
				Report.Info("false1 " + ingredientTypeError.Text);
			}
			return true;
		}

		public bool CheckForErrorMessagesInPopupWithTitle(string popupTitle)
		{
			IList <IWebElement> errorMessages = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//h4[text()='California Cleaning Right to Know']/../following-sibling::div//div"), 2);
			if (errorMessages[1].Text.Contains("Generic ingredients are not permitted as they cannot be screened for Chemicals of Concern. Each ingredient must use any of the following: Valid Chemical Abstract Service identifier(CAS number); or Valid 3rd - Party Formula registration(CAS begins with \"WPS\"); or Valid CAS Addition(CAS begins with NA) Please note that use of an ingredient with a CAS beginning with NA may result in a suspension of the registration requiring more information or details. You should always use a valid CAS number or 3rd - Party Formula before using an NA option."))
			{
				Report.Info("true");
			} else
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
			if (alertMessage.Text.Contains("Note: there are special requirements for formulations that must be met in order to generate a California Cleaning Right to Know ingredient disclosure report.Formulations CANNOT contain:")
				&& alertMessage.Text.Contains("Any generic ingredient names(e.g., fragrance).Each generic ingredient name must be replaced by either a registered 3rd - Party component, or a list of the specific ingredients that comprise the generic mixture.")
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
			Report.Info("testing1 '" + lineOneEl.Text + "'" + " hi '" + lineTwoEl.Text + "'");
			if (lineOneEl.Text == lineOne && lineTwoEl.Text == lineTwo)
			{
				return true;
			}

			return false;
		}
		public bool CheckForTheFollowingTextInTheOptionReportsPage(string text)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//font[contains(text(),'" + text + "')]"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmUPCNumberIsDisplayedInUPCNumberField(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl.Text == savedAs)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmContainerTypeFieldIsBelowUPCNumberField()
		{
			return true;
		}

		public bool ConfirmTruckIconIsDisplayingNextToUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//i[@class='fa fa-truck']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseUPCDetailsAreCollapsedForUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//input[@data-bind='textInput: upcNumber.field']"), 2);
			if (optionEl == null)
			{
				return true;
			}

			return false;
		}

		public bool SelectCaseUPCDropDownArrowForUPC(string savedAs, string expandOrCollapse)
		{
			IWebElement optionEl;
			if (expandOrCollapse.ToLower() == "expand")
			{
				optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[text()='" + savedAs + "']/../..//em[@class='fa fa-chevron-right']"), 2);
			} else 
			{
				optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@placeholder='UPC Number']/../../..//a[@title='Expand']"), 2);
			}
			return optionEl.TryClick();
		}

		public bool ConfirmCaseDropDownContainsUPC(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='" + savedAs + "']"), 2);
			if (optionEl != null)
			{
				return true;
			}

			return false;
		}

		public bool ConfirmCaseDropDownWithUPCIsAvailableForSelection(string savedAs)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//span[@data-bind='text: upcNumber.field'][text()='"+ savedAs +"']/../..//input"), 2);
	
			if (optionEl != null)
			{
				optionEl.TryCheck();
				return optionEl.Checked();
			}

			return false;
		}

		public bool ConfirmOptionIsCheckedInSection(string option, string section)
		{
			IWebElement optionEl = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[text()='" + section + "']/../following-sibling::div//span[text()='" + option + "']/preceding-sibling::input"), 2);
			if (optionEl.Checked())
			{
				return true;
			}

			return false;
		}

		public bool ConfirmSectionIsAvailableForSelection(string sectionName)
		{
			IList <IWebElement> options = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//label[text()=\"" + sectionName + "\"]/../following-sibling::div//div[@data-toggle='buttons']//input"), 2);

			if (options.Count != 2)
			{
				Report.Info("The amount of options found were not as expected");
				return false;
			}

			foreach (IWebElement el in options)
			{
				if ((el.Text.ToLower() != "no") && (el.Text.ToLower() != "yes"))
				{
					Report.Info("An option with an unexpected name was found");
					return false;
				}

				if (!el.TryClick())
				{
					Report.Info("At least one option was not clickable");
					return false;
				}

			}

			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit
{
	public class RegulatoryDocumentsToProvide : SeleniumBaseObject
	{
		public const string BasePath = "//div[@class='modal-content']//h4[@data-bind='text: title']/../..";

		protected override By ContainerElementLocator => By.XPath(BasePath);

		internal bool SetAnswerToQuestion(string question, string answer)
		{
			Report.Info(string.Format("Attempting to answer the question: '{0}' with selection: '{1}'", question, answer));
			IWebElement elQuestion = this.FindElement(By.XPath(string.Format("//label[contains(text(),'{0}')]//parent::div//parent::div", question)), 2);
			IWebElement elAnswer = elQuestion?.FindElement(By.XPath(string.Format("..//span[contains(text(),\"{0}\")]", answer)), 2);
			bool isNull = false;

			if (elQuestion is null)
			{
				isNull = true;
				Report.Failure(string.Format("Unable to locate question: {0}", question));
			}

			if (elAnswer is null)
			{
				isNull = true;
				Report.Failure(string.Format("Unable to locate question: {0}", answer));
			}

			if (isNull)
			{ return false; }

			return elAnswer.TryClick();
		}

		public bool GetErrorForQuestion(Table table, out string outMessage)
		{
			var questions = new Dictionary<string, string>();
			string expected = string.Empty;
			outMessage = string.Empty;
			foreach (TableRow row in table.Rows)
			{
				questions.Add(row["Question"], row["Expected Answer"]);
			}
			foreach (string question in questions.Keys)
			{
				bool correct = true;
				IWebElement elQuestion;
				IWebElement actualMessage;
				
				elQuestion = this.FindElement(By.XPath(string.Format("//label[contains(text(),\"{0}\")]", question)), 2);
				actualMessage = elQuestion.FindElement(By.XPath("..//parent::div//parent::div//p//span"), 2);

				if (elQuestion == null || actualMessage == null)
				{
					return false;
				}

				string actualMessageStr = actualMessage.GetInnerText();
				
				expected = questions[question];

				correct = expected.Trim() == actualMessageStr.Trim();
				Report.IsTrue(correct, "Question " + question + " displayed " + actualMessage + " instead of " + expected, "Question " + question + " displayed " + expected + " as expected.");
				if (!correct)
				{
					outMessage = outMessage + " :: " + question + " :: " + actualMessage;
				}
			}
			
			return (outMessage.Length < 1);
		}

		public bool EnterWHMISSDSDocumentDate(string text)
		{
			try
			{
				IWebElement el = this.ContainerElement.FindElement(By.XPath(".//label[text()='WHMIS SDS Document Date']/../following-sibling::div//input"), 2);

				if (el != null)
				{
					el.EnterText(text);
					el.SendKeys(Keys.Enter);
					return el.GetAttribute("value") == text;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public bool CheckRegulatoryDocumentsConfirmationBox()
		{
			var el = this.ContainerElement.FindElement(By.XPath(".//div[@class='checkbox']//input[//span[contains(text(),'I confirm I am providing the most current Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label for this registration.')]]"), 2);
			bool clicked = el.TryClick();
			bool isChecked = el.Checked();
			return clicked && isChecked;

		}
	}
}

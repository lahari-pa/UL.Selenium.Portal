using System;
using System.Collections.Generic;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
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
				IWebElement elQuestion = this.FindElement(By.XPath(string.Format("//label[contains(text(),\"{0}\")]", question)), 2);
				string actualMessage = elQuestion.FindElement(By.XPath("..//parent::div//parent::div//p//span"), 2).GetInnerText();
				expected = questions[question];

				correct = expected.Trim() == actualMessage.Trim();
				Report.IsTrue(correct, "Question " + question + " displayed " + actualMessage + " instead of " + expected, "Question " + question + " displayed " + expected + " as expected.");
				if (!correct)
				{
					outMessage = outMessage + " :: " + question + " :: " + actualMessage;
				}
			}
			return (outMessage.Length < 1);
		}

		public bool CheckAllInputFieldsAreRed()
		{
			bool allFieldsRed = true;

			//try doing all 3 using list
			IWebElement infoBox1 = this.containerElement.FindElement(By.XPath(".//div[@class='dropzone']"),2);
			string infobox1colourStr=infoBox1.GetCssValue("background-color");

			//Ilist? or use normal with ToList() but it breaks?
			IList<IWebElement> infoBoxes = this.containerElement.FindElements(By.XPath(".//div[@class='dropzone']"), 2);
			List<string> infoBoxColors = new List<string>();
			foreach(var item in infoBoxes)
			{
				infoBoxColors.Add(item.GetCssValue("background-color"));
			}

			//if list contains anything that is not (color code for the red background) = false otherwise = true

			//if (infoBoxColors.Find(x => x.Contains("TEST")))
			//{

			//}

			foreach (var item in infoBoxes)
			{

				//string boxHeader = item.FindElement(By.XPath("//parent::div//preceding-sibling::span"), 2);

				if (item.GetCssValue("background-color") == "#fff0f0") //may need to find correct expect colour code as string by debug
				{
					Report.Success("The Colour of the Input field was red"); //give text above field also?
				}
				else
				{
					Report.Failure("The colour of the Input field was not red"); //give text above field also?
					allFieldsRed = false;
				}
				


			}
			return allFieldsRed;

		}
	}
}

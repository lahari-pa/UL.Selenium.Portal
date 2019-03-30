using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mailosaur;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class SummaryPage : BaseObject
	{
		public const string BasePath = "//body[@class='summary']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> ListOfButtons()
		{
			return containerElement.FindElements(By.XPath(".//button")).Select(x => x.GetValue()).ToList();
		}
		public string UPCNumber()
		{
			return containerElement.FindElement(By.XPath(@"//div[./h2[starts-with(text(),""Provide the product's UPC(s)"")]]//tr/td[1]/div"), 2)?.Text.Trim();
		}
		public string ProductID()
		{
			var headerText = containerElement.FindElement(By.XPath(".//span[contains(@data-bind,'text: dataEntry.pname')]"), 2)?.Text;
			if (headerText == null)
			{
				return null;
			}
			var bracketsMatch = Regex.Match(headerText, @"\(\d+\)");
			if (!bracketsMatch.Success)
			{
				return null;
			}
			return bracketsMatch.ToString().Trim().TrimStart('(').TrimEnd(')');
		}

		public string GetAnswerToQuestion(string question)
		{
			var allQuestions = containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h3"));
			if (allQuestions.Count == 0)
			{
				return null;
			}

			var matchingQuestion = allQuestions.FirstOrDefault(x => x.GetValue().Contains(question));

			if (matchingQuestion != null)
			{
				var matchingAnswer = matchingQuestion.FindElement(By.XPath("../p[contains(@data-bind, 'Data')]"),2);
				if (matchingAnswer != null)
				{
					return matchingAnswer.GetValue();
				}
			}
			NTTQA_Reporting_Module.Reporting.Core.Report.Info("No suitable answer was found");
			return null;
		}

		public List<string> GetKitContents()
		{
			List<string> lGetKitContents = new List<string>();
			var allTableQuestions = containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h2"));
			if (allTableQuestions.Count == 0)
			{
				return lGetKitContents;
			}

			var matchingQuestion = allTableQuestions.FirstOrDefault(x => x.GetValue().Contains("Select Existing Registrations to include in the Kit"));

			if (matchingQuestion != null)
			{
				var matchingAnswers = matchingQuestion.FindElements(By.XPath("../table//tbody/tr//div"));
				foreach (var answer in matchingAnswers)
				{
					lGetKitContents.Add(answer.GetValue());
				}
			}

			return lGetKitContents;
		}

		public List<SummaryDocument> GetAdditionalDocuments()
		{
			List<SummaryDocument> listOfDocuments = new List<SummaryDocument>();
			var allTableQuestions = containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h2"));
			if (allTableQuestions.Count == 0)
			{
				return listOfDocuments;
			}

			var matchingQuestion = allTableQuestions.FirstOrDefault(x => x.GetValue().Contains("Additional documents you've requested"));

			if (matchingQuestion != null)
			{

				var matchingAnswers = matchingQuestion.FindElements(By.XPath("../table//tbody/tr"));
				foreach (var answer in matchingAnswers)
				{
					var DocumentName = answer.FindElement(By.XPath(".//td[1]/div"), 2);
					var DocumentLang = answer.FindElement(By.XPath(".//td[2]/div"), 2);

					if (DocumentName != null && DocumentLang != null)
					{
						SummaryDocument thisSummaryDocument = new SummaryDocument() {DocumentName=DocumentName.GetValue(), DocumentLanguage = DocumentLang.GetValue()};
						listOfDocuments.Add(thisSummaryDocument);
					}

				}
			}

			return listOfDocuments;
		}

		public IWebElement LoadingSpinner()
		{
			return containerElement.FindElement(By.XPath(@".//span[contains(@data-bind,""dataEntry.pname() === 'undefined (undefined)"") and contains(text(),'Loading')]"), 2);
		}
	}

	class SummaryDocument
	{
		public string DocumentName { get; set; }
		public string DocumentLanguage { get; set; }
	}
}

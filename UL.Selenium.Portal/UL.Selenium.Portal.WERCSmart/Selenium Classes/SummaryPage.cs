using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	class SummaryPage : BaseObject
	{
		public const string BasePath = "//body[@class='summary']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public List<string> ListOfButtons()
		{
			return this.containerElement.FindElements(By.XPath(".//button")).Select(x => x.GetValue()).ToList();
		}
		public string UPCNumber()
		{
			return this.containerElement.FindElement(By.XPath(@"//div[./h2[starts-with(text(),""Provide the product's UPC(s)"")]]//tr/td[1]/div"), 2)?.Text.Trim();
		}
		public string ProductID()
		{
			string headerText = this.containerElement.FindElement(By.XPath(".//span[contains(@data-bind,'text: dataEntry.pname')]"), 2)?.Text;
			if (headerText == null)
			{
				return null;
			}
			Match bracketsMatch = Regex.Match(headerText, @"\(\d+\)");
			if (!bracketsMatch.Success)
			{
				return null;
			}
			return bracketsMatch.ToString().Trim().TrimStart('(').TrimEnd(')');
		}

		public string GetAnswerToQuestion(string question)
		{
			ReadOnlyCollection<IWebElement> allQuestions = this.containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h3"));
			if (allQuestions.Count == 0)
			{
				return null;
			}

			IWebElement matchingQuestion = allQuestions.FirstOrDefault(x => x.GetValue().Contains(question));

			if (matchingQuestion != null)
			{
				IWebElement matchingAnswer = matchingQuestion.FindElement(By.XPath("../p[contains(@data-bind, 'Data')]"), 2);
				if (matchingAnswer != null)
				{
					return matchingAnswer.GetValue();
				}
			}
			NTTQA.Selenium.Reporting.Core.Report.Info("No suitable answer was found");
			return null;
		}

		public List<string> GetKitContents()
		{
			var lGetKitContents = new List<string>();
			ReadOnlyCollection<IWebElement> allTableQuestions = this.containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h2"));
			if (allTableQuestions.Count == 0)
			{
				return lGetKitContents;
			}

			IWebElement matchingQuestion = allTableQuestions.FirstOrDefault(x => x.GetValue().Contains("Select Existing Registrations to include in the Kit"));

			if (matchingQuestion != null)
			{
				ReadOnlyCollection<IWebElement> matchingAnswers = matchingQuestion.FindElements(By.XPath("../table//tbody/tr//div"));
				foreach (IWebElement answer in matchingAnswers)
				{
					lGetKitContents.Add(answer.GetValue());
				}
			}

			return lGetKitContents;
		}

		public List<SummaryDocument> GetAdditionalDocuments()
		{
			var listOfDocuments = new List<SummaryDocument>();
			ReadOnlyCollection<IWebElement> allTableQuestions = this.containerElement.FindElements(By.XPath(".//div[@class='summary-question-container']/h2"));
			if (allTableQuestions.Count == 0)
			{
				return listOfDocuments;
			}

			IWebElement matchingQuestion = allTableQuestions.FirstOrDefault(x => x.GetValue().Contains("Additional documents you've requested"));

			if (matchingQuestion != null)
			{

				ReadOnlyCollection<IWebElement> matchingAnswers = matchingQuestion.FindElements(By.XPath("../table//tbody/tr"));
				foreach (IWebElement answer in matchingAnswers)
				{
					IWebElement DocumentName = answer.FindElement(By.XPath(".//td[1]/div"), 2);
					IWebElement DocumentLang = answer.FindElement(By.XPath(".//td[2]/div"), 2);

					if (DocumentName != null && DocumentLang != null)
					{
						var thisSummaryDocument = new SummaryDocument() { DocumentName = DocumentName.GetValue(), DocumentLanguage = DocumentLang.GetValue() };
						listOfDocuments.Add(thisSummaryDocument);
					}

				}
			}

			return listOfDocuments;
		}

		public IWebElement LoadingSpinner()
		{
			return this.containerElement.FindElement(By.XPath(@".//span[contains(@data-bind,""dataEntry.pname() === 'undefined (undefined)"") and contains(text(),'Loading')]"), 2);
		}
	}

	class SummaryDocument
	{
		public string DocumentName { get; set; }
		public string DocumentLanguage { get; set; }
	}
}

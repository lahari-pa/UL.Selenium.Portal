using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;

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
			Report.Info("No suitable answer was found");
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

		private List<IWebElement> UpcHeadings => this.containerElement.FindElements(By.XPath(".//h2[contains(text(),'UPC')]//ancestor::div[@class='summary-question-container']/table/thead/tr[contains(@data-bind,'values')]/th"), 2).ToList();

		private string[] UPCHeadingTitles => this.UpcHeadings.Select(x => x.FindElement(By.XPath("./div"), 2).Text).ToArray();

		public bool DoesUPCHeadingsContain(string headingName)
		{

			var newList = this.UPCHeadingTitles;
			if (newList.Contains(headingName))
			{
				return true;
			}
			else
			{
				Report.Info("Did not find the Heading name: " + headingName + ". Heading names found are as follows: " + string.Join(",", newList));
				return false;
			}
			
		}
		private List<IWebElement> IngredientHeadings => this.containerElement.FindElements(By.XPath(".//h2[contains(text(),'Ingredients')]//ancestor::div[@class='summary-question-container']/table/thead/tr[contains(@data-bind,'values')]/th"), 2).ToList();

		private string[] IngredientHeadingTitles => this.IngredientHeadings.Select(x => x.FindElement(By.XPath("./div"), 2).Text).ToArray();

		public string IngredientType(string ingredient)
		{
			//find row for ingredient want, then add all values from ingreident types column to list
			IWebElement ingredientRow = this.containerElement.FindElement(By.XPath($".//h2[contains(text(),'Ingredients')]//ancestor::div[@class='summary-question-container']//tr[.//div[text()='{ingredient}']]"), 2);
			var newList = this.IngredientHeadingTitles;
			int i = 1;
			bool foundColumn = false;
			foreach(var item in newList)
			{
				if(item== "Ingredient Type")
				{
					Report.Info($"The Ingredient Type column was in position {i} in the table");
					foundColumn = true;
					break;
 
				}
				i++;

			}
			if (!foundColumn)
			{
				Report.Failure("Was not able to find the column Ingredient Type in the Ingredients table");
				return null;
			}

			IWebElement correctIngredientTypeCell = ingredientRow.FindElement(By.XPath($".//td[{i}]"),2);



			string displayedType = correctIngredientTypeCell.FindElement(By.XPath($".//div"), 2).Text;
			return displayedType;

			

			

		}

		public bool IngredientTypesMatch(string ingredient,string type)
		{
			
			string actualType = this.IngredientType(ingredient);
			if(type=="NA")
			{
				return (actualType == null);
			}
			return (actualType == type);

		}

		public List<string>FunctionalPurposes(string ingredient)
		{
			//find row for ingredient want, then add all values from ingreident types column to list
			IWebElement functionalRow = this.containerElement.FindElement(By.XPath($".//h2[contains(text(),'Ingredients')]//ancestor::div[@class='summary-question-container']//tr[.//div[text()='{ingredient}']]"), 2);
			var newList = this.IngredientHeadingTitles;
			int i = 1;
			bool foundColumn = false;
			foreach (var item in newList)
			{
				if (item == "Functional Purpose")
				{
					Report.Info($"The Functional Purpose column was in position {i} in the table");
					foundColumn = true;
					break;

				}
				i++;

			}
			if (!foundColumn)
			{
				Report.Failure("Was not able to find the column Functional Purpose in the Ingredients table");
				return null;
			}

			IWebElement correctIngredientTypeCell = functionalRow.FindElement(By.XPath($".//td[{i}]"), 2);

			//List<IWebElement> ingredientTypeEls = correctIngredientTypeCell.FindElements(By.XPath($".//div//div"), 2).ToList();

			string ingredientTypeEls = correctIngredientTypeCell.FindElement(By.XPath($".//div"), 2).Text;
			string replacedStr = ingredientTypeEls.Replace("\r\n", "");			
			string finalStr = replacedStr.TrimEnd(',');
			List<string> result = finalStr.Split(new char[] { ',' }).ToList();			
			return result;

		}

		
		public bool FunctionalPurposesMatch(string ingredient, List<string> chosenPurposes)
		{
			
			List<string> actualPurposes = this.FunctionalPurposes(ingredient);

			var diffFound = new List<string>();
			Report.Info($"The Number of found Functional Purposes was:{actualPurposes.Count()}");			
			if(actualPurposes.Count == 1)
			{
				if (actualPurposes[0]=="" && chosenPurposes.Contains("NA"))
				{
					Report.Info("There were Functional purposes found as expected");
					return true;
				}
			}
			
			foreach (var item in actualPurposes)
			{
				if (!chosenPurposes.Contains(item))
				{
					diffFound.Add(item);
					Report.Info($"Found difference: {item}");
				}
			}

			if (diffFound.Count == 0)
			{
				return true;
			}
			return false;




		}
		public bool DoesIngredientHeadingsContain(string headingName)
		{

			var newList = this.IngredientHeadingTitles;
			if (newList.Contains(headingName))
			{
				return true;
			}
			else
			{
				Report.Info("Did not find the Heading name: " + headingName + ". Heading names found are as follows: " + string.Join(",", newList));
				return false;
			}

		}
		
		

	}

	class SummaryDocument
	{
		public string DocumentName { get; set; }
		public string DocumentLanguage { get; set; }
	}
}

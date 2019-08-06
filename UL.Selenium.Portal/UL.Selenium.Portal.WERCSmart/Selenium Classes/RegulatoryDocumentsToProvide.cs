using System;
using NTTQA.Selenium.BaseClasses;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit
{
	class RegulatoryDocumentsToProvide : SeleniumBaseObject
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
	}
}

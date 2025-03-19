using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class ModalDialogPrototype : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[@role='dialog'][contains(@style,'display: block;')]//div[@class='modal-content']");
		private string Title => this.FindElement(By.ClassName("modal-title"), 1)?.Text;
		private IWebElement HeaderCloseButton => this.FindElement(By.XPath(".//div[@class='modal-header']//button[@class='close']"), 1);
		private IWebElement FooterButton(string buttonLabel) => this.FindElement(By.XPath($".//div[@class='modal-footer']//*[text()=\"{buttonLabel}\"]"), 1);
		private string ModalBody => this.FindElement(By.XPath($".//div[@class='modal-body']"), 1)?.Text;

		#endregion

		#region Class Methods
		public string TitleGet()
		{
			Report.Info($"Attempting to get modal title.");
			return this.Title;
		}
		public bool ModalTitleExists()
		{
			Report.Info($"Attempting to confirm modal title exists.");
			return this.Title != null;
		}

		public bool HeaderCloseButtonExists()
		{
			Report.Info($"Attempting to confirm modal header close button exists.");
			return this.HeaderCloseButton != null;
		}

		public bool HeaderCloseButtonClick()
		{
			Report.Info($"Attempting to click modal header close button.");
			return this.HeaderCloseButton.TryClick();
		}

		public bool FooterButtonExists(string buttonLabel)
		{
			Report.Info($"Attempting to confirm modal footer \"{buttonLabel}\" button exists.");
			return this.FooterButton(buttonLabel) != null;
		}

		public bool FooterButtonClick(string buttonLabel)
		{
			Report.Info($"Attempting to click modal footer \"{buttonLabel}\" button.");
			return this.FooterButton(buttonLabel).TryClick();
		}
		public bool IsModalDisplayed()
		{
			Report.Info($"Attempting to confirm if the modal is displayed.");
			var modalElement = this.FindElement(this.ContainerElementLocator, 1);
			if (modalElement != null)
			{
				return modalElement.Displayed;
			}
			else
			{
				Report.Info("Modal Element is not found.");
				return false;
			}
		}
		public string GetModalBodyText()
		{
			Report.Info($"Attempting to get the text in the modal body.");
			return this.ModalBody;
		}
		#endregion
	}
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class ModalDialogPrototype : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[@role='dialog'][contains(@style,'display: block;')]//div[@class='modal-content']");
		private string Title => this.FindElement(By.ClassName("modal-title"), 1)?.Text;
		private IWebElement HeaderCloseButton => this.FindElement(By.XPath(".//div[@class='modal-header']//button[@class='close']"), 1);
		private List<IWebElement> FooterButtonsList => [.. this.FindElements(By.XPath(".//div[@class='modal-footer']//*[text()]"), 1)];
		private IWebElement FooterButton(string buttonLabel) => this.FooterButtonsList.FirstOrDefault(x => x.Text.Trim().Equals(buttonLabel, StringComparison.Ordinal));
		private string ModalBodyString => this.FindElement(By.XPath($".//div[@class='modal-body']"), 1)?.Text.Trim();

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
			IWebElement modalElement = this.FindElement(this.ContainerElementLocator, 1);
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
			return this.ModalBodyString;
		}
		#endregion
	}

	public class QuestionFormGroup(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Label => this.ContainerElement.FindElement(By.XPath(".//label[text()]"), 1)?.Text;
		private IWebElement TextInput => this.ContainerElement.FindElement(By.XPath(".//input[@type='text']"), 1);
		//private IWebElement ValidationGlyphicon => this.ContainerElement.FindElement(By.XPath(".//span[contains(@class,'glyphicon')]"), 1);
		#endregion

		#region Class Methods
		#region Text Input Methods
		public bool TextInputExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' Question Form Group text input exists.");
			return this.TextInput != null;
		}

		public bool TextInputClick()
		{
			Report.Info($"Attempting to click '{this.Label}' Question Form Group text input.");
			return this.TextInput.TryClick();
		}

		public string TextInputPlaceholderText()
		{
			Report.Info($"Attempting to get '{this.Label}' Question Form Group text input placeholder text.");
			return this.TextInput.GetAttribute("placeholder");
		}

		public bool TextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter into '{this.Label}' Question Form Group text input the text: '{inputText}'");
			return this.TextInput.TryEnterText(inputText);
		}

		public string TextInputText()
		{
			Report.Info($"Attempting to get '{this.Label}' Question Form Group text input value.");
			return this.TextInput.GetValue();
		}
		#endregion


		#endregion
	}

	public class CheckboxOption(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		private IWebElement Checkbox => this.ContainerElement.FindElement(By.XPath(".//input[@type='checkbox']"), 1);
		public string Label => this.ContainerElement.FindElement(By.XPath("./descendant-or-self::*[text()]"), 1)?.Text;
		private IWebElement RemoveButton => this.ContainerElement.FindElement(By.XPath(".//a[@title='Remove']"), 1);
		#endregion

		#region Class Methods
		#region Checkbox Methods
		public bool CheckboxExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' checkbox exists.");
			return this.Checkbox != null;
		}

		public bool CheckboxClick()
		{
			Report.Info($"Attempting to click '{this.Label}' checkbox.");
			return this.Checkbox.TryClick();
		}

		public bool CheckboxChecked()
		{
			Report.Info($"Attempting to confirm '{this.Label}' checkbox is checked.");
			return this.Checkbox.Checked();
		}
		#endregion

		#region Remove Button Methods
		public bool RemoveButtonExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' checkbox remove button exists.");
			return this.RemoveButton != null;
		}

		public bool RemoveButtonClick()
		{
			Report.Info($"Attempting to click '{this.Label}' checkbox remove button.");
			return this.RemoveButton.TryClick();
		}
		#endregion
		#endregion
	}
}

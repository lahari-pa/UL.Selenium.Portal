using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

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
		private List<QuestionFormGroup> QuestionFormGroupsList => [.. this.ContainerElement.FindElements(By.XPath(".//div[contains(@class,'form-group')]"), 1).Select(x => new QuestionFormGroup(x))];
		public QuestionFormGroup QuestionFormGroupByLabel(string label) => this.QuestionFormGroupsList.FirstOrDefault(x => x.Label.Equals(label, StringComparison.Ordinal));
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

		public List<string> QuestionFormGroupLabelsList()
		{
			Report.Info($"Attempting to get modal question form group labels list.");
			return [.. this.QuestionFormGroupsList.Select(x => x.Label)];
		}
		#endregion
	}

	public class QuestionFormGroup(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		public string Label => this.ContainerElement.FindElement(By.XPath("./label[text()]"), 1)?.Text; //Must be direct descendant
		private IWebElement TextInput => this.ContainerElement.FindElement(By.XPath(".//input[@type='text']"), 1);
		private IWebElement ValidationGlyphicon => this.ContainerElement.FindElement(By.XPath(".//span[contains(@class,'glyphicon')]"), 1);
		private List<CheckboxOption> CheckboxOptionsList => [.. this.ContainerElement.FindElements(By.XPath(".//div[./input[@type='checkbox']]"), 1).Select(x => new CheckboxOption(x))];
		public CheckboxOption CheckboxOptionByLabel(string optionLabel) => this.CheckboxOptionsList.FirstOrDefault(x => x.Label.Equals(optionLabel, StringComparison.Ordinal));
		private IWebElement DropdownInput => this.ContainerElement.FindElement(By.XPath(".//select"), 1);
		private List<IWebElement> DropdownOptionsList => [.. this.DropdownInput.FindElements(By.XPath(".//option"), 1)];
		private IWebElement DropdownOption(string optionLabel) => this.DropdownOptionsList.FirstOrDefault(x => x.Text.Trim().Equals(optionLabel, StringComparison.Ordinal));
		private IWebElement ErrorMessage => this.ContainerElement.FindElement(By.XPath(".//p[@class='form-error']"), 1);
		private List<RadioOption> RadioOptionsList => [.. this.ContainerElement.FindElements(By.XPath(".//div[@class='radio']"), 1).Select(x => new RadioOption(x))];
		public RadioOption RadioOptionByLabel(string optionLabel) => this.RadioOptionsList.FirstOrDefault(x => x.Label.Equals(optionLabel, StringComparison.Ordinal));
		#endregion

		#region Class Methods
		#region Text Input Methods
		public bool TextInputExists()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group text input exists.");
			return this.TextInput != null;
		}

		public bool TextInputClick()
		{
			Report.Info($"Attempting to click {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group text input.");
			return this.TextInput.TryClick();
		}

		public string TextInputPlaceholderText()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group text input placeholder text.");
			return this.TextInput.GetAttribute("placeholder");
		}

		public bool TextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter into {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group text input the text: '{inputText}'");
			return this.TextInput.TryEnterText(inputText);
		}

		public string TextInputValue()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group text input value.");
			return this.TextInput.GetValue();
		}
		#endregion
		#region Validation Glyphicon Methods
		public bool ValidationGlyphiconExists()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Validation Glyphicon exists.");
			return this.ValidationGlyphicon != null;
		}

		public bool ValidationGlyphiconDisplayed()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Validation Glyphicon is displayed.");
			return this.ValidationGlyphicon.Displayed;
		}

		public bool ValidationGlyphiconIsType(string type)
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Validation Glyphicon is '{type}' type.");
			return this.ValidationGlyphicon.GetAttribute("class").Contains($"glyphicon-{type}");
		}
		#endregion
		#region Checkbox Options List Methods
		public bool CheckboxOptionsListExists()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Checkbox Options list exists.");
			return !this.CheckboxOptionsList.IsNullOrEmpty();
		}
		public List<string> CheckboxOptionsListLabelsList()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Checkbox options label list");
			return [.. this.CheckboxOptionsList.Select(x => x.Label)];
		}

		public bool CheckboxOptionByLabelExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group '{optionLabel}' Checkbox Option exists.");
			return this.CheckboxOptionByLabel(optionLabel) != null;
		}
		#endregion
		#region Dropdown Input Methods
		public bool DropdownInputExists()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Dropdown input exists.");
			return this.DropdownInput != null;
		}

		public bool DropdownInputClick()
		{
			Report.Info($"Attempting to click {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Dropdown input.");
			return this.DropdownInput.TryClick();
		}

		public string DropdownInputValue()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Dropdown input value.");
			return this.DropdownInput.GetValue();
		}

		public List<string> DropdownOptionsLabelsList()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Gropup Dropdown Options labels list.");
			return [.. this.DropdownOptionsList.Select(x => x.Text.Trim())];
		}

		public bool DropdownOptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group '{optionLabel}' Dropdown Option exists.");
			return this.DropdownOption(optionLabel) != null;
		}

		public bool DropdownOptionClick(string optionLabel)
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group '{optionLabel}' Dropdown Option.");
			return this.DropdownOption(optionLabel).TryClick();
		}
		#endregion
		#region Error Message Methods
		public bool ErrorMessageDisplayed()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Error Message is displayed.");
			return this.ErrorMessage.Displayed;
		}

		public string ErrorMessageText()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Error Message.");
			return this.ErrorMessage.Text;
		}
		#endregion
		#region Radio Options List Methods
		public bool RadioOptionsListExists()
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Radio Options list exists.");
			return !this.RadioOptionsList.IsNullOrEmpty();
		}

		public List<string> RadioOptionsLabelsList()
		{
			Report.Info($"Attempting to get {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group Radio Options Labels list.");
			return [.. this.RadioOptionsList.Select(x => x.Label)];
		}

		public bool RadioOptionByLabelExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm {(!this.Label.IsNullOrEmpty() ? $"'{this.Label}'" : "this")} Question Form Group '{optionLabel}' Radio Option exists.");
			return this.RadioOptionByLabel(optionLabel) != null;
		}
		#endregion
		#endregion
	}

	public class RadioOption(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		private IWebElement Radio => this.ContainerElement.FindElement(By.XPath(".//input[@type='radio']"), 1);
		public string Label => this.ContainerElement.FindElement(By.XPath(".//label/descendant-or-self::*[text()]"), 1)?.Text.Trim();
		#endregion

		#region Class Methods
		public bool RadioExists()
		{
			Report.Info($"Attempting to confirm '{this.Label}' radio button exists.");
			return this.Radio != null;
		}

		public bool RadioClick()
		{
			Report.Info($"Attempting to click '{this.Label}' radio button.");
			return this.Radio.TryClick();
		}

		public bool RadioSelected()
		{
			Report.Info($"Attempting to confirm '{this.Label}' radio button is selected.");
			return this.Radio.Selected;
		}
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

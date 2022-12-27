using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
//using OpenQA.Selenium.DevTools.Performance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class RuleWriter : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[//div[contains(text(),'Rule Writer')]]");

		public string _buttonString;

		private IWebElement Button => this.ContainerElement.FindElement(By.XPath($"//body[//div[contains(text(),'Rule Writer')]]//div[@class='widgetStyleContents']//iframe[@id='Widget1FRAME']"), 2);

		public bool FoundContainerEl()
		{
			//GeneralUtilities.SwitchToFrame($"<contains(@data-frameid,'Rule Writer')>");
			GeneralUtilities.SwitchToDefaultContent();
			var el = this.ContainerElement;
			//var thing = SeleniumBrowser.WebBrowser.FindElement(By.XPath($"//body[//div[@id='Widget1HEA' and contains(text(),'Rule Writer')]]"), 5);
			if (el!=null)
			{
				Report.Info($"The el was found as expected...");
				return true;
			}
			int x = 0;
			while (el == null & x < 20)
			{
				el = this.ContainerElement;
				Delay.Seconds(5);
				x++;
			}
			return el != null;
		}

		public bool FoundContainerElAlt()
		{

			GeneralUtilities.SwitchToDefaultContent();
			//SeleniumBrowser.WebBrowser.SwitchTo().ParentFrame();
			var containerEl = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//body[//div[@id='Widget1HEA']]"), 5);
			if (containerEl != null)
			{
				Report.Info($"Container Found");

				string containerElStr = containerEl.Text;
				if (containerElStr.Contains("Rule Writer"))
				{
					Report.Info($"Container Found with text: 'Rule Writer'");
					return true;
				}
			}
			int x = 0;
			while (containerEl == null & x < 20)
			{
				containerEl = this.ContainerElement;
				Delay.Seconds(5);
				x++;
			}
			if (containerEl != null)
			{
				Report.Info($"Container Found");

				string containerElStr = containerEl.Text;
				if (containerElStr.Contains("Rule Writer"))
				{
					Report.Info($"Container Found with text: 'Rule Writer'");

					return true;
				}
			}
			return false;


		}
		public bool ClickButton(string buttonName)
		{
			_buttonString = buttonName;
			if (this.Button == null)
			{
				Report.Error($"Could not find a button with the name {buttonName}");
				return false;
			}
			return this.Button.TryClick();
		}

		public bool ClickAllRulesButton()
		{
			//switch to iframe needed or? revert go back to parent needed?
			
			Report.Info("Switching to iFrame");
			SeleniumWebDriver.CurrentDriver.SwitchTo().Frame("Widget2FRAME");
			IWebElement el= SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@"//input[@type='button' and @title='All Rules']"), 10);
			if (el == null)
			{
				Report.Error($"Could not find a button with the name All Rules");
				return false;
			}
			return el.TryClick();

		}


		public bool ClickAllRulesButtonAlt()
		{

			Report.Info("Switching to iFrame");
			GeneralUtilities.SwitchToDefaultContent();
			SeleniumWebDriver.CurrentDriver.SwitchTo().ParentFrame();
			GeneralUtilities.SwitchToFrame($"<contains(@data-frameid,'Rule Writer')>");
			IWebElement el = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath(@"//input[@type='button' and @title='All Rules']"), 10);
			if (el == null)
			{
				Report.Error($"Could not find a button with the name All Rules");
				return false;
			}
			bool clicked = el.TryClick();
			GeneralUtilities.ExitIFrame();
			return clicked;

		}

		public class RightClickRuleMenu : BaseObject
		{
			public const string BasePath = "//div[@id='srSelectRules_Panel1']";

			[FindsBy(How = How.XPath, Using = BasePath)]
			protected override IWebElement containerElement { get; set; }

			public bool MenuExists()
			{
				return this.containerElement.Displayed;
			}

			public List<string> GetAllOptions()
			{
				return this.containerElement.FindElements(By.XPath(".//tr")).Select(x => x.GetValue()).ToList();
			}

			public bool SelectOption(string selectOption)
			{
				ReadOnlyCollection<IWebElement> listOfOptions = this.containerElement.FindElements(By.XPath(".//tr"));
				IWebElement matchingOption = listOfOptions.FirstOrDefault(x => x.GetValue().Contains(selectOption));
				if (matchingOption == null)
				{
					List<string> Options = this.GetAllOptions();
					Report.Error("No matching option was found. Options were: " + string.Join(",", Options));
					return false;
				}

				return matchingOption.TryClick();
			}


		}

		public class RuleWriter_RulesEditor : SeleniumBaseObject
		{
			protected override By ContainerElementLocator => By.XPath("//form[@name='form1']//table[@id='srSelectRules_divRounded']");

			private IWebElement FilterButton => this.ContainerElement.FindElement(By.XPath("//a[@id='srSelectRules_lnkFilter']"), 2);

			private IWebElement FilterTable => this.ContainerElement.FindElement(By.XPath(".//table[@id='srSelectRules_tblFilter']"), 2);

			private string _searchHeader;

			private IWebElement SearchRow => this.FilterTable.FindElement(By.XPath($".//table//tr[td/span[contains(text(),'{_searchHeader}')]]"), 2);

			private IWebElement SearchDropDown => this.SearchRow.FindElement(By.XPath($".//select"), 2);

			private IWebElement SearchTextBox => this.SearchRow.FindElement(By.XPath(".//input"), 2);

			private IWebElement ApplyBtn => this.FilterTable.FindElement(By.XPath(".//input[@type='submit'][@title='Apply']"), 2);

			private IWebElement DataTable => this.ContainerElement.FindElement(By.XPath(".//div[@id='srSelectRules_divSRData']//table"), 2);

			private List<IWebElement> ColHeaders => this.DataTable.FindElements(By.XPath($".//tr[contains(@class,'Header')]//a"), 2).ToList();

			internal bool ClickFilterBtn()
			{
				return this.FilterButton != null && this.FilterButton.TryClick();
			}

			internal bool SelectFilterType(string filterName, string searchType)
			{
				_searchHeader = filterName;
				if (this.SearchRow == null)
				{
					Report.Error($"Could not find the filter for {filterName}");
					return false;
				}
				if (this.SearchDropDown == null)
				{
					Report.Error($"Could not find the dropdown for the {filterName} row.");
					return false;
				}
				List<IWebElement> DropDownOptions = this.SearchDropDown.FindElements(By.XPath(".//option"), 2).ToList();
				if (DropDownOptions.Count == 0)
				{
					Report.Error("There were no options to select.");
					return false;
				}
				string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
				foreach (var option in DropDownOptions)
				{
					Match match = Regex.Match(option.Text, ToMatch);
					if (match.Success)
					{
						this.SearchDropDown.Select(option.Text);
						return true;
					}
				}
				Report.Error($"There were no options that matched the string {searchType}");
				return false;
			}

			internal bool EnterFilterText(string searchHeader, string searchText)
			{
				_searchHeader = searchHeader;
				if (this.SearchRow == null)
				{
					Report.Error($"Could not find the filter for {searchHeader}");
					return false;
				}
				if (this.SearchTextBox == null)
				{
					Report.Error($"Could not find the text box for the filter {searchHeader}");
					return false;
				}
				else
				{
					return this.SearchTextBox.TryEnterText(searchText);
				}
			}

			internal bool ClickApplyFilterBtn()
			{
				return this.ApplyBtn == null ? false : this.ApplyBtn.TryClick();
			}

			internal bool FindItem(string columnHeader, string userName)
			{
				Delay.Seconds(1);
				if (this.ColHeaders.Count() < 1)
				{
					Report.Error("Could not find the column headers.");
					return false;
				}
				string ToMatch = $@"^(\* |! |){Regex.Escape(columnHeader)}";
				int colNum = 0;
				foreach (var header in this.ColHeaders)
				{
					Match match = Regex.Match(header.Text.Trim(), ToMatch);
					if (match.Success)
					{
						break;
					}
					else
					{
						colNum++;
					}
				}
				if (colNum >= this.ColHeaders.Count())
				{
					Report.Error($"Could not find the column with the header {columnHeader}");
					return false;
				}
				List<IWebElement> rows = this.DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
				ToMatch = $"^{Regex.Escape(userName)}$";
				foreach (var row in rows)
				{
					Match match = Regex.Match(row.Text.Trim(), ToMatch);
					if(row.Text.Trim().Contains(userName))
					{
						Report.Info($"Row was found...");
						return true;
					}			

					
				}
				Report.Error($"Could not find the username {userName}");
				return false;
			}

			internal IWebElement GetRuleRowFromTable(string columnHeader, string userName)
			{
				Delay.Seconds(1);
				if (this.ColHeaders.Count() < 1)
				{
					Report.Error("Could not find the column headers.");
					return null;
				}
				string ToMatch = $@"^(\* |! |){Regex.Escape(columnHeader)}";
				int colNum = 0;
				foreach (var header in this.ColHeaders)
				{
					Match match = Regex.Match(header.Text.Trim(), ToMatch);
					if (match.Success)
					{
						break;
					}
					else
					{
						colNum++;
					}
				}
				if (colNum >= this.ColHeaders.Count())
				{
					Report.Error($"Could not find the column with the header {columnHeader}");
					return null;
				}
				List<IWebElement> rows = this.DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
				ToMatch = $"^{Regex.Escape(userName)}$";
				foreach (var row in rows)
				{
					Match match = Regex.Match(row.Text.Trim(), ToMatch);
					if (row.Text.Trim().Contains(userName))
					{
						Report.Info($"Row was found...");
						return row;
					}
				}
				Report.Error($"Could not find the username {userName}");
				return null;
			}


		}

		public class RuleWriter_NewRule : SeleniumBaseObject
		{
			protected override By ContainerElementLocator => By.XPath("//form[@name='form1']//tbody");

			private IWebElement FilterButton => this.ContainerElement.FindElement(By.XPath("//a[@id='srSelectRules_lnkFilter']"), 2);

			public List<IWebElement> RuleBoxElements => this.ContainerElement.FindElements(By.XPath($"//table[@id='rblRuleType']//tr"), 2).ToList();

			private IWebElement CopySelectedRuleButton => this.ContainerElement.FindElement(By.XPath("//input[@id='chkCopyRule']"), 2);

			private IWebElement EnterNameBox => this.ContainerElement.FindElement(By.XPath("//input[@name='txtRuleName']"), 2);

			private IWebElement OKButton => this.ContainerElement.FindElement(By.XPath("//input[@name='btnOk']"), 2);



			private IWebElement CopyRuleLabelText => this.ContainerElement.FindElement(By.XPath("//span[@id='lblCopyRule']"), 2);




			internal bool ClickFilterBtn()
			{
				return this.FilterButton != null && this.FilterButton.TryClick();
			}

			internal bool SelectGivenRuleType(string type)
			{
				
				var ruleEls = this.RuleBoxElements;

				IWebElement wantedRule = null;
				bool wantedRuleFound = false;

				foreach(var item in ruleEls)
				{
					if (item.Text!=null)
					{
						if(item.Text.Contains(type))
						{
							wantedRule = item;
							wantedRuleFound = true;
						}
						
					}
				}

				if (wantedRuleFound == false)
				{
					Report.Info($"The wanted rule was not found.");
					return false;

				}

				try
				{
					wantedRule.TryClick();

					ruleEls = this.RuleBoxElements;

					IWebElement checkedRule = null;
					bool checkedRuleFound = false;

					foreach (var item in ruleEls)
					{
						if (item.Text != null)
						{
							if (item.Text.Contains(type))
							{
								checkedRule = item;
								checkedRuleFound = true;
							}

						}
					}

					var checkedEl = checkedRule.FindElement(By.XPath($".//input[@checked='checked']"), 2);
					return checkedEl != null;
					
				}
				catch
				{
					//do nothing
					Report.Info($"");
					return false;
				}
				
			}


			internal bool ClickCopySelectedRule()
			{
				var el = this.CopySelectedRuleButton;
				if(el==null)
				{
					Report.Info($"The el was null");
					return false;
				}

				return el.TryClick();
			}

			internal bool CopyRuleActive()
			{
				var el = this.CopyRuleLabelText;
				if (el == null)
				{
					Report.Info($"The el was null");
					return false;
				}
				return el != null;
			}
			 internal bool EnterNameText(string value)
			{
				var el = this.EnterNameBox;
				if (el == null)
				{
					Report.Info($"The el was null");
					return false;
				}
				return el.TryEnterText(value);
			}


			internal bool ClickOKButton()
			{
				var el = this.OKButton;
				if (el == null)
				{
					Report.Info($"The el was null");
					return false;
				}

				return el.TryClick();
			}




		}


		public class RuleWriter_RuleView : SeleniumBaseObject
		{
			protected override By ContainerElementLocator => By.XPath("//form[@name='Form1']//tbody");

			private IWebElement WillContainResultBox => this.ContainerElement.FindElement(By.XPath("//textarea[@name='EditCalculation']"), 2);

			private IWebElement SaveButton => this.ContainerElement.FindElement(By.XPath("//input[@name='btnSave']"), 2);




			internal string GetContainedResultsText()
			{
				var el = this.WillContainResultBox;
				if (el == null)
				{
					Report.Info($"The el was null");
					return null;
				}

				return el.Text;
				
			}

			internal bool ClearThenEnterTextIntoContainedResultsBox(string value)
			{
				var el = this.WillContainResultBox;
				if (el == null)
				{
					Report.Info($"The el was null");
					return false;
				}
				el.ClearTextBox();
				var foundText = this.WillContainResultBox.GetValue();				
				if (foundText.IsNullOrEmpty())
				{
					return el.TryEnterText(value);
				}
				else
				{
					Report.Info($"The text was not cleared succesfully, returning");
					return false;
				}
				

			}

			internal bool ClickSaveButton()
			{
				var el = this.SaveButton;
				if (el == null)
				{
					Report.Info($"The el was null");
					return false;
				}

				return el.TryClick();
			}

			internal bool WaitForRulesEditorToBeGone()
			{
				var el = this.ContainerElement;
				if(el.IsNullOrEmpty())
				{
					Report.Info($"The el was not found as expected...");
					return true;
				}
				int x = 0;
				while(el!=null & x<20)
				{
					el = this.ContainerElement;
					Delay.Seconds(5);
					x++;
				}
				return el == null;
			}







		}
	}
}

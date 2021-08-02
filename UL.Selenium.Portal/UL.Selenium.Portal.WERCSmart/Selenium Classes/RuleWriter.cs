using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class RuleWriter : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[//div[@id='Widget1HEA' and contains(text(),'Rule Writer')]]");

		private string _buttonString;

		private IWebElement Button => ContainerElement.FindElement(By.XPath($"//body[//div[@id='Widget1HEA' and contains(text(),'Rule Writer')]]//div[@class='widgetStyleContents']//iframe[@id='Widget1FRAME']"), 2);

		public bool ClickButton(string buttonName)
		{
			_buttonString = buttonName;
			if (Button == null)
			{
				Report.Error($"Could not find a button with the name {buttonName}");
				return false;
			}
			return Button.TryClick();
		}

		public bool ClickAllRulesButton()
		{
			//switch to iframe needed or? revert go back to parent needed?
			
			Report.Info("Switching to iFrame");
			SeleniumBrowser.WebBrowser.SwitchTo().Frame("Widget1FRAME");
			IWebElement el= SeleniumBrowser.WebBrowser.FindElement(By.XPath(@"//input[@type='button' and @title='All Rules']"), 10);
			if (el == null)
			{
				Report.Error($"Could not find a button with the name All Rules");
				return false;
			}
			return el.TryClick();

		}

		public class RuleWrtier_RulesEditor : SeleniumBaseObject
		{
			protected override By ContainerElementLocator => By.XPath("//form[@name='form1']//table[@id='srSelectRules_divRounded']");

			private IWebElement FilterButton => ContainerElement.FindElement(By.XPath("//a[@id='srSelectRules_lnkFilter']"), 2);

			private IWebElement FilterTable => ContainerElement.FindElement(By.XPath(".//table[@id='srUsers_tblFilter']"), 2);

			private string _searchHeader;

			private IWebElement SearchRow => FilterTable.FindElement(By.XPath($".//table//tr[td/span[contains(text(),'{_searchHeader}')]]"), 2);

			private IWebElement SearchDropDown => SearchRow.FindElement(By.XPath($".//select"), 2);

			private IWebElement SearchTextBox => SearchRow.FindElement(By.XPath(".//input"), 2);

			private IWebElement ApplyBtn => FilterTable.FindElement(By.XPath(".//input[@type='submit'][@title='Apply']"), 2);

			private IWebElement DataTable => ContainerElement.FindElement(By.XPath(".//div[@id='srUsers_divSRData']//table"), 2);

			private List<IWebElement> ColHeaders => DataTable.FindElements(By.XPath($".//tr[contains(@class,'Header')]//a"), 2).ToList();

			internal bool ClickFilterBtn()
			{
				return FilterButton != null && FilterButton.TryClick();
			}

			internal bool SelectFilterType(string filterName, string searchType)
			{
				_searchHeader = filterName;
				if (SearchRow == null)
				{
					Report.Error($"Could not find the filter for {filterName}");
					return false;
				}
				if (SearchDropDown == null)
				{
					Report.Error($"Could not find the dropdown for the {filterName} row.");
					return false;
				}
				List<IWebElement> DropDownOptions = SearchDropDown.FindElements(By.XPath(".//option"), 2).ToList();
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
						SearchDropDown.Select(option.Text);
						return true;
					}
				}
				Report.Error($"There were no options that matched the string {searchType}");
				return false;
			}

			internal bool EnterFilterText(string searchHeader, string searchText)
			{
				_searchHeader = searchHeader;
				if (SearchRow == null)
				{
					Report.Error($"Could not find the filter for {searchHeader}");
					return false;
				}
				if (SearchTextBox == null)
				{
					Report.Error($"Could not find the text box for the filter {searchHeader}");
					return false;
				}
				else
				{
					return SearchTextBox.TryEnterText(searchText);
				}
			}

			internal bool ClickApplyFilterBtn()
			{
				return ApplyBtn == null ? false : ApplyBtn.TryClick();
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
				if (colNum >= ColHeaders.Count())
				{
					Report.Error($"Could not find the column with the header {columnHeader}");
					return false;
				}
				List<IWebElement> rows = this.DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
				ToMatch = $"^{Regex.Escape(userName)}$";
				foreach (var row in rows)
				{
					Match match = Regex.Match(row.Text.Trim(), ToMatch);
					if (match.Success)
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
				if (colNum >= ColHeaders.Count())
				{
					Report.Error($"Could not find the column with the header {columnHeader}");
					return null;
				}
				List<IWebElement> rows = this.DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
				ToMatch = $"^{Regex.Escape(userName)}$";
				foreach (var row in rows)
				{
					Match match = Regex.Match(row.Text.Trim(), ToMatch);
					if (match.Success)
					{
						Report.Info($"Row was found...");
						return row;
					}
				}
				Report.Error($"Could not find the username {userName}");
				return null;
			}
		}
		}
}

using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using System.Text;
using System.Linq;
using UL.Automation.Utilities.Functions;
using System.IO;
using System.Text.RegularExpressions;
using UL.Automation.SpecFlow.Classes;
using System.Net;
using System.Drawing;
using TechTalk.SpecFlow;
using System.Globalization;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public static class GeneralUtilities
	{
		public static bool StudioWaitForSpinner()
		{
			try
			{
				IList<IWebElement> spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
				while (spinner.Any(x => x.Displayed))
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool ExitIFrame()
		{
			try
			{
				return SeleniumWebDriver.CurrentDriver.ExitIFrame();
			}
			catch (Exception ex)
			{
				Report.Error("Failed to switch frame. Exception was thrown: " + ex.Message);
				return false;
			}
		}

		public static string ReplaceWithContext(string input)
		{
			string pattern = @"<context:(\w+)>";
			Match match = Regex.Match(input, pattern);
			if (match.Success)
			{
				string contextVar = match.Groups[1].Value;
				input = Regex.Replace(input, pattern, (string)Context.GetFromContext(contextVar));

			}
			return input;

		}
		public static bool StudioWaitForSpinner(int maxSecondsToWait)
		{
			try
			{
				for (int i = 0; i < maxSecondsToWait; i++)
				{
					IList<IWebElement> spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
					if (!spinner.Any(x => x.Displayed))
					{
						return true;
					}
					Delay.Seconds(Delay.SpeedFactor * 1);
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Wait_for_load_finish()
		{
			// wait up to 2 seconds for the loading bar to become visible
			SeleniumBrowser.WebBrowser.WaitUntilElementVisible(By.XPath("//body[contains(@class,'pace-running')]"), 2);
			// waits up to 60 seconds for the loading bar to then become invisible
			return SeleniumBrowser.WebBrowser.WaitUntilElementInvisible(By.XPath("//body[contains(@class,'pace-running')]"), 60);
		}

		public static bool Loading_Active()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//body[contains(@class,'pace')]")) != null;
		}



		public static void ScrollToBottomOfPage()
		{
			((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
		}

		public static void ScrollToTopOfPage()
		{
			((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.scrollTo(0, 0)");
		}

		public static bool WaitForRefreshToDisappear(IWebElement button, int maxWaitTime = 60)
		{
			try
			{
				return button.WaitUntilElementInvisible(By.XPath(".//i[contains(@class,'fa-refresh')]"), maxWaitTime);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool WaitForSpinnerToDisappear(IWebElement button, int waitMax = 60)
		{
			try
			{
				return button.WaitUntilElementInvisible(By.XPath(".//i[contains(@class,'fa fa-spinner')]"), waitMax);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool CloseAjaxPopup()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//button[@data-dismiss = 'modal' and text()='Close']"), 2).TryClick();
		}

		public static bool AjaxPopupExists()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//p[contains(text(),'There was an error processing your request. Please try again.')]"), 2) != null;
		}

		public static List<string> CvsUpcs()
		{
			var web = new HtmlWeb();
			HtmlDocument document = web.Load(@"https://www.upcitemdb.com/info-cvs");
			HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(@"//a[@name='upclist']//following-sibling::div//ul//li//div[@class='rImage']/a");
			var upcValues = nodes.Select(x => x.InnerText).ToList();
			return upcValues;
		}

		public static bool TrySelect(IWebElement el, string optionValue, bool ignoreWhitespace = false)
		{
			try
			{
				if (el.TagName != "select")
				{
					return false;
				}
				if (!ignoreWhitespace)
				{
					el.Select(optionValue);
					return el.SelectedOption() == optionValue;
				}
				IList<IWebElement> options = el.FindElements(By.XPath("./option"), 1);
				foreach (IWebElement thisOptionEl in options)
				{
					string thisOptionValue = thisOptionEl.GetValue();
					if (thisOptionValue.Replace(" ", string.Empty) != optionValue.Replace(" ", string.Empty))
					{
						continue;
					}
					el.Select(thisOptionValue);
					return el.SelectedOption() == thisOptionValue;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string StripSpecialChars(string text)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in text)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
		}

		public static string RemoveLineBreaks(string fullString)
		{
			var splitByLineBreak = fullString.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
			var trimmedList = splitByLineBreak.Select(x => x.TrimEnd(' '));
			//List<string> trimmedList = new List<string>();
			//splitByLineBreak.ForEach(x => trimmedList.Add(x.TrimEnd(' ')));
			string tidyString = string.Join(" ", trimmedList);
			return tidyString;
		}

		public static bool DeleteFileFromDownloadsFolder(string fileName)
		{

			string downloadsFolder = KnownFolders.GetPath(KnownFolder.Downloads);
			Report.Info("Deleting any existing files with name: " + fileName + " in the directory: " + downloadsFolder + ".");
			var files = Directory.GetFiles(downloadsFolder, "*" + fileName, SearchOption.TopDirectoryOnly);
			foreach (var file in files)
			{
				try
				{
					Report.Info("Deleting: " + file);
					File.Delete(file);
				}
				catch (Exception ex)
				{
					Report.Error("ERROR DELETING FILE: " + ex.Message);
				}
			}

			if (!Directory.GetFiles(downloadsFolder, "*" + fileName, SearchOption.TopDirectoryOnly).Any())
			{
				return true;
			}
			return false;
		}

		public static string GenerateRandomString(int charCount)
		{
			var rand = new Random();
			char[] chars = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
				'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
			string str = string.Empty;
			for (int i = 0; i < charCount; i++)
			{
				float caps = rand.Next(0, 1);
				char insert = chars[rand.Next(1, chars.Count())];
				if (caps > .5)
				{
					string temp = insert.ToString().ToUpper();
					insert = Convert.ToChar(temp);
				}
				str = str + insert;
			}

			return str;
		}

		public static string[] RowValuesFromContext(this TableRow row)
		{
			var vals = row.Values.Select(x =>
			{
				if (Context.GetFromContextRegex(x, out var result))
				{
					return result.ToString();
				}
				return x;
			});
			return vals.ToArray();
		}

		public static Table TableValuesFromContext(this Table table)
		{
			var newTable = new Table(table.Header.ToArray());
			foreach (var row in table.Rows)
			{
				newTable.AddRow(row.RowValuesFromContext());
			}
			return newTable;
		}

		public static bool CheckABCOrder(List<string> list)
		{
			var sortedList = new List<string>();
			foreach (string item in list)
			{
				sortedList.Add(item);
			}

			sortedList.Sort();

			for (int i = 0; i < list.Count; i++)
			{
				if (sortedList[i] != list[i])
				{
					return false;
				}

			}

			return true;
		}
		public static Bitmap CreateBitmapFromURL(string url)
		{
			WebClient myClient = new WebClient();
			Stream myStream = myClient.OpenRead(url);
			return new Bitmap(myStream);
		}

		public static Bitmap CreateBitmapFromFile(string file)
		{
			return new Bitmap(file);
		}

		public static bool CompareBitmaps(Bitmap bitmap1, Bitmap bitmap2)
		{
			return GeneralFunctions.CompareImages(bitmap1, bitmap2);
		}
		public static bool SwitchToFrame(string frame = "Widget1FRAME")
		{
			string[] values = frame.Split(',');
			bool output = true;
			Regex regex = new Regex("<(.+)>");
			string teststring = "";
			foreach (var val in values)
			{
				try
				{
					if (teststring.StartsWith("<"))
					{
						teststring = $"{teststring},{val}";
					}
					else
					{
						teststring = val;
					}
					if (teststring.StartsWith("<") && !teststring.EndsWith(">"))
					{
						continue;
					}
					Match match = regex.Match(teststring);
					if (!match.Success)
					{
						output = SeleniumWebDriver.CurrentDriver.SwitchToIFrame(val) || (SeleniumWebDriver.CurrentDriver.ExitIFrame() && SeleniumWebDriver.CurrentDriver.SwitchToIFrame(val));
						teststring = "";
					}
					else
					{
						string position = match.Groups[1].Value;
						IWebElement iFrame = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath($"//iframe[{position}]"), 2);
						SeleniumWebDriver.CurrentDriver.SwitchTo().Frame(iFrame);
						output = true;
						teststring = "";
					}
				}
				catch (Exception ex)
				{
					SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
					Report.Error($"Failed to switch frame {frame}. Exception was thrown: " + ex.Message);
					return false;
				}
			}
			return output;
		}


		public static bool CheckCBAOrder(List<string> list)
		{
			var sortedList = new List<string>();
			foreach (string item in list)
			{
				sortedList.Add(item);
			}

			sortedList.Sort();
			sortedList.Reverse();

			for (int i = 0; i < list.Count; i++)
			{
				if (sortedList[i] != list[i])
				{
					return false;
				}

			}
			return true;
		}

		public static void SwitchToDefaultContent()
		{
			SeleniumWebDriver.CurrentDriver.SwitchTo().DefaultContent();
		}

		public static void OpenNewTabAndNavigateTo(string url)
		{
			string currentHandle = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			((IJavaScriptExecutor)SeleniumBrowser.WebBrowser).ExecuteScript("window.open();");
			SeleniumBrowser.WebBrowser.SwitchTo().Window(SeleniumBrowser.WebBrowser.WindowHandles.Last());
			if (url.ToLower().Contains("savedas"))
			{
				url = (string)Context.GetFromContext(url);
			}
			SeleniumBrowser.WebBrowser.Url = url;
			SeleniumBrowser.WebBrowser.WaitForPageLoad();
		}

		public static bool IsValidDate(string value, string dateFormats)
		{
			DateTime tempDate;
			bool validDate = DateTime.TryParseExact(value, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
			if (validDate)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

	}

	public class RetailerAbbreviations
	{
		private Dictionary<string, string> _abbr;
		public Dictionary<string, string> Map { get { return this._abbr; } }
		public RetailerAbbreviations()
		{
			this._abbr = new Dictionary<string, string> {
				{ "Dollar General", "DG" },
				{ "Dollar Tree", "DT" },
				{ "Walmart", "WM" },
				{ "Albertsons (includes Albertsons, LLC and New Albertson's Inc.)", "AL" },
				{ "Northgate Market", "NM" },
				{ "Weis", "WE" },
				{ "Publix", "PX" },
				{ "Ultra/Standard", "ST" },
				{ "HEB", "HE" },
				{ "Delhaize America (All Retail Banners)", "DA" },
				{ "Costco", "CO" },
				{ "HyVee", "HV" },
				{ "Dick's Sporting Goods", "DI" },
				{ "Sears/K-Mart", "SE" },
				{ "New Egg", "NE" },
				{ "Canadian Tire", "CT" },
				{ "Tractor Supply", "TS" },
				{ "No Retailer/No UPC Product", "NR" },
				{ "WinCo Foods", "WC" },
				{ "Michaels", "MI" },
				{ "HD Supply", "HS" },
				{ "Price Chopper", "PR" },
				{ "The Home Depot", "HD" },
				{ "Ahold | DelHaize USA", "AH" },
				{ "Lowe's", "LW" },
				{ "SuperValu", "SV" },
				{ "CVS", "CV" },
				{ "Genuine Parts", "GP" },
				{ "Big Lots", "BL" },
				{ "Staples", "SP" },
				{ "Office Depot", "OD" },
				{ "Meijer", "MJ" },
				{ "Rite Aid", "RA" },
				{ "Essendant", "US" },
				{ "Bed Bath and Beyond (including Harmon, Buy Buy Baby, and Christmas Tree Shops)", "BB" },
				{ "Schnuck's", "SC" },
				{ "Smart & Final", "SF" },
				{ "Target", "TG" },
				{ "O'Reilly", "OR" },
				{ "Walgreens", "WG" },
				{ "Dietary Supplements", "DS" },
				{ "Wakefern", "WF" },
				{ "Unified", "UF" },
				{ "Petco", "PC" },
				{ "Kohl's", "KO" },
				{ "Family Dollar", "FD" },
				{ "Harbor Freight Tools", "HF" },
				{ "Target Canada", "TC" },
				{ "Autozone", "AZ" },
				{ "99 Cents", "99" },
				{ "McLane", "ML" },
				{ "Wal-Mart/SAM'S CLUB", "WM" },
				{ "Kroger", "KG" },
				{ "A&P", "AP" },
				{ "Amazon", "AM" },
				{ "Dollar Tree Stores, Inc. / Greenbrier International, Inc", "DT" },
				{ "Optoro", "OP" },
				{ "TopCo", "TP" },
				{ "Subscription", "SB" },
				{ "Save Mart Supermarkets", "SM" },
				{"Ace Hardware Corporation", "AC" },
				{ "Best Buy", "BE" },
				{ "Albertsons Companies", "SW" },
				{ "Enterprise license", "EL" },
				{"United Natural Foods, Inc.","UN"}

			};
		}

		public class StateAbbreviations
		{

			private Dictionary<string, string> _stateAbbr;
			public Dictionary<string, string> Map { get { return this._stateAbbr; } }

			public StateAbbreviations()
			{
				this._stateAbbr = new Dictionary<string, string> {
				{ "Alabama", "AL" },
				{ "Alaska", "AK" },
				{ "Arizona", "AZ" },
				{ "Arkansas", "AR" },
				{ "California", "CA" },
				{ "Colorado", "CO" },
				{ "Connecticut", "CT" },
				{ "Delaware", "DE" },
				{ "Florida", "FL" },
				{ "Georgia", "GA" },
				{ "Hawaii", "HI" },
				{ "Idaho", "ID" },
				{ "Illinois", "IL" },
				{ "Indiana", "IN" },
				{ "Iowa", "IA" },
				{ "Kansas", "KS" },
				{ "Kentucky", "KY" },
				{ "Louisiana", "LA" },
				{ "Maine", "ME" },
				{ "Maryland", "MD" },
				{ "Massachusetts", "MA" },
				{ "Michigan", "MI" },
				{ "Minnesota", "MN" },
				{ "Mississippi", "MS" },
				{ "Missouri", "MO" },
				{ "Montana", "MT" },
				{ "Nebraska", "NE" },
				{ "Nevada", "NV" },
				{ "New Hampshire", "NH" },
				{ "New Jersey", "NJ" },
				{ "New Mexico", "NM" },
				{ "New York", "NY" },
				{ "North Carolina", "NC" },
				{ "North Dakota", "SC" },
				{ "Ohio", "OH" },
				{ "Oklahoma", "OK" },
				{ "Oregon", "OR" },
				{ "Pennsylvania", "PA" },
				{ "Rhode Island", "RI" },
				{ "South Carolina", "SC" },
				{ "South Dakota", "SD" },
				{ "Tennessee", "TN" },
				{ "Texas", "TX" },
				{ "Utah", "UT" },
				{ "Vermont", "VT" },
				{ "Virginia", "VA" },
				{ "Washington", "WA" },
				{ "West Virginia", "WV" },
				{ "Wisconsin", "WI" },
				{ "Wyoming", "WY" }
			};
			}

		}

		/// <summary>
		/// If the input string exists as a key (retailer full name) then return the corresponding key (retailer abbreviation)
		/// Otherwise return the original string
		/// </summary>
		public string TryConvertToAbbreviation(string input)
		{
			int x = 0;
			bool foundMapping = false;
			while (foundMapping == false && x < 6)
			{
				Delay.Seconds(2);
				var abbreviationMappings = this.Map;
				if (abbreviationMappings.ContainsKey(input))
				{
					abbreviationMappings.TryGetValue(input, out string retailer);
					if (retailer != null)
					{
						Report.Info($"Found the retailer abbrevation: {input}");
						return retailer;
					}
				}
				else
				{
					Report.Info("List does not contain input");
				}
				Report.Info($"Failed to find the input retailer: {input} in the Retailer abbreviations list");
				x++;

			}
			return input;

		}

	











	}

}

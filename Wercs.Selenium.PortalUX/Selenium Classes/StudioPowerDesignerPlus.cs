using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text.pdf.parser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class StudioPowerDesignerPlus : BaseObject
	{
	public const string BasePath = "//iframe[contains(@src, 'PowerTools']";

	[FindsBy(How = How.XPath, Using = BasePath)]
	protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait)
		{
			SeleniumBrowser.WebBrowser.SwitchTo()
				.Frame(SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[contains(@src, 'PowerTools']")));
			
			return base.Wait_for_load(secondsToWait);
		}

		public bool SetLanguage(string language)
		{
			var languageSelect = containerElement.FindElement(By.XPath(".//select[@id='ucSelectLanguageddlLang']"));
			if (languageSelect != null)
			{
				languageSelect.Select(language);
				return (languageSelect.SelectedOption() == language);
			}

			return false;
		}

		public bool EnterSubFormatFilter(string subFormatFilter)
		{
			var subFormatInput = containerElement.FindElement(By.XPath(".//input[@id='ftree']"));
			if (subFormatInput != null)
			{
				subFormatInput.EnterText(subFormatFilter);
				return (subFormatInput.GetValue() == subFormatFilter);
			}

			return false;
		}

		public bool SelectFormatFromTree(string formatName)
		{
			var TopLevelListItems = containerElement.FindElements(By.XPath(".//div[@id='tree']/ul/li")).ToList();

			foreach (var ListItem in TopLevelListItems)
			{
				var subListTopLevel = ListItem.FindElement(By.XPath(".//ul"));

				if (subListTopLevel.GetAttribute("style").Contains("none"))
				{
					var expander = ListItem.FindElement(By.XPath(".//span[@class='fancytree-expander']"));
					if (expander != null)
					{
						expander.TryClick();
					}
				}

				var listOfSubItems = subListTopLevel.FindElements(By.XPath(".//li//span[@class='fancytree-title']"));
				var matchingItem = listOfSubItems.FirstOrDefault(x => x.GetValue() == formatName);

				if (matchingItem != null)
				{
					return matchingItem.TryClick();
				}

				if (subListTopLevel.GetAttribute("style").Contains("block"))
				{
					var expander = ListItem.FindElement(By.XPath(".//span[@class='fancytree-expander']"));
					if (expander != null)
					{
						expander.TryClick();
					}
				}
			}

			return false;
		}

		//new, new from, edit, edit overwrite
		public bool SelectProductIDOption(string option)
		{
			var selectProductDiv = containerElement.FindElement(By.XPath(".//div[@id='productSelect']"));
			var labels = selectProductDiv.FindElements(By.XPath(".//input/following-sibling::label"));
			IWebElement matchingLabel = null;
			switch (option)
			{
				case "new":
					matchingLabel = labels.FirstOrDefault(x => x.GetValue() == "New Product");
					break;
				case "new from":
					matchingLabel = labels.FirstOrDefault(x => x.GetValue() == "New product from existing product");
					break;
				case "edit":
					matchingLabel = labels.FirstOrDefault(x => x.GetValue() == "Edit existing product");
					break;
				case "edit overwrite":
					matchingLabel = labels.FirstOrDefault(x => x.GetValue() == "Edit existing product, first overwrite data from selected product");
					break;
				default:
					throw new Exception("No matching option was found");
			}

			if (matchingLabel != null)
			{
				return matchingLabel.TryClick();
			}

			return false;
		}
	}
}

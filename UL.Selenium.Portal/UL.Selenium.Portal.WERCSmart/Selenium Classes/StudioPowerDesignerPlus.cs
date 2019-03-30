using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NTTQA_Automation_Classes.Base_Classes;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class StudioPowerDesignerPlus : BaseObject
	{
		public const string BasePath = "//div[contains(@class, 'container')]";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			// if Home/ Welcome has not opened by default, open it
			//StudioPowerDesignerPlusDesignMode pdPlusDMode = new StudioPowerDesignerPlusDesignMode();
			//if (pdPlusDMode.Wait_for_load(5))
			//{
			//	pdPlusDMode.ClickMenuAndSubmenuOptions("Home");
			//}
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;
			bool foundPopup = false;
			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Welcome"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Welcome");
					Report.Screenshot();
					foundPopup = true;
					break;
				}
			}

			if (!foundPopup)
			{
				return false;
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(secondsToWait))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				return true;
			}

			return false;
		}


		public bool SetLanguage(string language)
		{
			var languageSelect = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[@id='ucSelectLanguageddlLang']"), 2);
			if (languageSelect != null)
			{
				languageSelect.Select(language);
				return (languageSelect.SelectedOption() == language);
			}
			return false;
		}

		public bool EnterSubFormatFilter(string subFormatFilter)
		{
			var subFormatInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@id='ftree']"), 2);
			if (subFormatInput != null)
			{
				subFormatInput.EnterText(subFormatFilter);
				return (subFormatInput.GetValue() == subFormatFilter);
			}
			else
			{
				Report.Info("Failed to locate subformat input");
			}
			return false;
		}

		public string SelectedSubFormat()
		{
			return "";
		}

		public bool SelectRandomFormat()
		{
			var tree = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='tree']/ul"), 2);

			if (tree == null)
			{
				return false;
			}

			var results = tree.FindElements(By.XPath(".//li/span[(./span[contains(@class,'title')])]"), 2);
			if (results == null)
			{
				return false;
			}
			Random rand = new Random();

			int index = rand.Next(results.Count - 1);

			return results[index].TryClick();

		}

		public bool SelectFormat(string subformat, string format)
		{
			var tree = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='tree']/ul"), 2);

			if (tree == null)
			{
				return false;
			}

			var results = tree.FindElement(By.XPath(".//li/span[(./span[contains(@class,'title') and starts-with(text(),'" + format + "')])]"), 2);
			if (results == null)
			{
				return false;
			}
			Report.Info("Found format");

			var allFormats = results.FindElement(By.XPath("./following-sibling::ul"), 2);
			if (allFormats == null)
			{
				return false;
			}

			var el = allFormats.FindElement(By.XPath(".//li/span[(./span[contains(@class,'title') and starts-with(text(),'" + subformat + "')])]"), 2);

			if (el == null)
			{
				Report.Info("Failed to find subformat");
				return false;
			}
			Report.Info("Found format");
			return el.TryClick();

		}

		public bool EnterSourceProduct(string sourceProduct)
		{
			var enterField = this.containerElement.FindElement(By.XPath(".//input[@id='sourceproductSelectselectProdTB']"));
			enterField.EnterText(sourceProduct);
			return (enterField.GetValue() == sourceProduct);
		}

		public bool ClickOpenFilterDialog()
		{
			var enterField = this.containerElement.FindElement(By.XPath(".//input[@id='sourceproductSelectselProd']"));
			return enterField.TryClick();
		}

		public bool ClickRefreshButton()
		{
			var enterField = this.containerElement.FindElement(By.XPath(".//button[contains(@class, 'refresh')]"));
			return enterField.TryClick();
		}

		public string GetSourceProductName()
		{
			var label = this.containerElement.FindElement(By.XPath(".//label[@id='sourceproductSelectlblProductName']"), 5);
			if (label != null)
			{
				return label.GetValue().Trim();
			}

			return "";

		}

		public bool ClickContinueButton()
		{
			var enterField = this.containerElement.FindElement(By.XPath(".//input[@id='continueBtn']"));
			return enterField.TryClick();
		}

		//new, new from, edit, edit overwrite
		public bool SelectProductIDOption(string option)
		{
			var selectProductDiv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@id='productSelect']"), 2);
			if (selectProductDiv == null)
			{
				return false;
			}
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

	class StudioPowerDesignerPlusDesignMode : BaseObject
	{
		public const string BasePath = "//div[@id='main']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 30)
		{
			try
			{
				//get the window
				StudioUtilites.SwitchToWindow("Wercs Studio");
				SeleniumBrowser.WebBrowser.SwitchTo().DefaultContent();
				IWebElement frame =
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe[contains(@src, 'workspaceDesignMode')]"));
				SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
				this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
				return base.Wait_for_load(30);
			}
			catch (Exception e)
			{
				return false;
			}


		}

		public bool QuickSearchExists()
		{
			try
			{
				var input = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='ucSelectProdselectProdTB']"), 2);
				if (input != null)
				{
					return input.Displayed;
				}

				return false;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public void QuickSearch(string id)
		{
			var input = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='ucSelectProdselectProdTB']"), 2);
			input.EnterText(id);
			input.SendKeys(Keys.Return);
			Delay.Seconds(5);
		}



		//Menu items: Format/SubFormat, Products, Components, Phrases, Tools
		public bool ClickMenuAndSubmenuOptions(string menuItem, string submenuItem = "")
		{
			var listOfMenuItems = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[@id='navmenu']//ul[@id='navmenu-h']/li[(./ul/li or ./a[@id='aHomeMenuItem'])]/a"));
			var matchingMenuItem = listOfMenuItems.FirstOrDefault(x => x.GetValue().Contains(menuItem));

			if (matchingMenuItem == null)
			{
				Report.Info("Failed to find menu item: " + menuItem);
				return false;
			}

			if (!matchingMenuItem.TryClick())
			{
				Report.Info("Failed to click menu item: " + menuItem);
			}

			if (submenuItem.Length > 0)
			{
				var matchingSubMenuItem = matchingMenuItem.FindElements(By.XPath("./../ul/li/a"))
					.FirstOrDefault(x => x.GetValue() == submenuItem);

				if (matchingSubMenuItem == null)
				{
					Report.Info("Failed to find sub menu item: " + submenuItem);
					return false;
				}


				if (!matchingSubMenuItem.TryClick())
				{
					Report.Info("Failed to click sub menu item: " + submenuItem);
				}
			}


			return true;
		}

		public bool ClickTabOption(string tabName)
		{

			var listOfTabs = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//ul[@id='navmenu-h']/li[(./a[@class='first'])]"));
			IWebElement tab;
			switch (tabName.ToLower())
			{
				case "authoring":
					tab = listOfTabs.FirstOrDefault(x => x.GetAttribute("id") == "MH_Authoring");
					break;
				case "product":
					tab = listOfTabs.FirstOrDefault(x => x.GetAttribute("id") == "MH_ProductTools");
					break;
				case "wizards":
					tab = listOfTabs.FirstOrDefault(x => x.GetAttribute("id") == "MH_WizardTools");
					break;
				case "workflow":
					tab = listOfTabs.FirstOrDefault(x => x.GetAttribute("id") == "MH_WorkflowTools");
					break;
				case "my toolbar":
					tab = listOfTabs.FirstOrDefault(x => x.GetAttribute("id") == "MH_MyTools");
					break;
				default:
					Report.Error("Please provide valid tab name - authoring, product, wizards, workflow or my toolbar");
					return false;
			}

			if (tab != null)
			{
				return tab.TryClick();
			}
			else
			{
				Report.Error("Tab was not found: " + tabName);
				return false;

			}

		}

		public bool ClickEditButton()
		{
			for (int i = 0; i < 30; i++)
			{
				try
				{
					var editButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='customize-my-toolbar']"), 1);
					if (editButton != null)
					{
						return editButton.TryClick();
					}
				}
				catch (Exception e)
				{
					Delay.Seconds(1);
				}
			}

			return false;
		}

		public bool ClickApplyRulesButton()
		{
			for (int i = 0; i < 30; i++)
			{
				try
				{
					var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='cmdRuleWriter']"), 1);
					if (button != null)
					{
						return button.TryClick();
					}
				}
				catch (Exception e)
				{
					Delay.Seconds(1);
				}
			}

			return false;
		}


		public bool ClickToolBarItem(string item)
		{
			Report.Info("Beginning click tool bar item: " + item);
			var aLinks = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='divBtmToolbars']//a[not(contains(@style, 'none'))]"));

			if (aLinks.Count == 0)
			{
				Report.Info("No toolbar items found.");
				return false;
			}
			IWebElement matchingLink;
			switch (item.ToLower())
			{
				case "formulation":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdFormulation");
					break;
				case "attributes":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdAttributes");
					break;
				case "publish":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdPublish");
					break;
				case "workflow":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdWorkflow");
					break;
				case "refresh":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdRefreshDoc");
					break;
				case "preview":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdPreviewPDF");
					break;
				case "validation":
				case "validate":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdValidateReport");
					break;
				case "generic subsets":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdGenSub");
					break;
				case "send subformat change report":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdSfReport");
					break;
				case "document queue":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdDocQueue");
					break;
				case "in out":
					matchingLink = aLinks.FirstOrDefault(x => x.GetAttribute("id") == "cmdCheckout");
					break;
				default:
					Report.Error("Please provide a suitable toolbar item name. You sent: " + item);
					return false;
			}

			if (matchingLink != null)
			{
				Report.Info("Found matching link on tool bar to click");
				return matchingLink.TryClick();
			}
			else
			{
				Report.Error("No matching link was found: " + item);
				Report.Info("Found: " + string.Join(",", aLinks.Select(x => x.GetAttribute("id")).ToList()));
				return false;
			}
		}


		public bool ClickOptions()
		{
			var optionButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//i[@id='doc-options-button']"));
			if (optionButton != null)
			{
				return optionButton.TryClick();
			}

			return false;
		}

		public bool ClickRefresh()
		{
			var refreshButton = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='cmdRefreshDoc']"));
			if (refreshButton != null)
			{
				return refreshButton.TryClick();
			}

			return false;
		}

		public bool ClickValidate()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='cmdValidateReport']"));
			if (button != null)
			{
				return button.TryClick();
			}

			return false;
		}

		public bool ClickToggleProductCompare()
		{
			var button = SeleniumBrowser.WebBrowser.FindElement(By.Id("toggle-product-compare-popup"));
			if (button != null)
			{
				return button.TryClick();
			}

			return false;
		}

		public string GetCurrentStatusOfDataCode(string code)
		{
			var dataCodes = this.containerElement.FindElements(By.XPath(".//div[@id='divCanvasContent']//span[(./img)]"));
			IWebElement button;
			switch (code)
			{
				case "DPQAPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath(".//img")).GetAttribute("src") == "DPQAPF");
					break;
				case "CAWC":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQACA");
					break;
				case "EPAN":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAEP");
					break;
				case "HCM":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAHC");
					break;
				case "OTC":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAPP");
					break;
				case "RAUNDW":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQARA");
					break;
				case "UNIFFC":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAUN");
					break;
				case "WSWC":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAWS");
					break;
				case "DCQAPF":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "DPQAPF");
					break;
				case "VOCQAPF":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "VCQA");
					break;
				case "RSQAPF":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "RSQAPF");
					break;
				case "RSQAHDPF":
					button = dataCodes.FirstOrDefault(x => x.GetAttribute("name") == "RSQAHDPF");
					break;
				default:
					Report.Error("Provide a valid data code");
					return "";
			}

			if (button != null)
			{
				var img = button.FindElement(By.XPath(".//img"), 2);
				if (img != null)
				{
					string imgSrc = img.GetAttribute("src");
					if (imgSrc.Contains("pass"))
					{
						return "pass";
					}
					if (imgSrc.Contains("fail"))
					{
						return "fail";
					}
					if (imgSrc.Contains("na"))
					{
						return "na";
					}
				}

			}
			return "";
		}

		public bool DoubleClickDataCode(string code)
		{
			var dataCodes = this.containerElement.FindElements(By.XPath(".//div[@id='divCanvasContent']//td[(./span/img)]"));
			IWebElement button;
			switch (code)
			{
				case "DPQAPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAPF");
					break;
				case "CAWC":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQACA");
					break;
				case "EPAN":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAEP");
					break;
				case "HCM":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAHC");
					break;
				case "OTC":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAPP");
					break;
				case "RAUNDW":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQARA");
					break;
				case "UNIFFC":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAUN");
					break;
				case "WSWC":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DPQAWS");
					break;
				case "DCQAPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "DCQAPF");
					break;
				case "VCQA":
				case "VOCQAPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "VCQA");
					break;
				case "RSQAPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "RSQAPF");
					break;
				case "RSQHADPF":
				case "RSQAHDPF":
					button = dataCodes.FirstOrDefault(x => x.FindElement(By.XPath("./span")).GetAttribute("name") == "RSQAHDPF");
					break;
				default:
					Report.Error("Provide a valid data code. The code you have provided: " + code + " does not exist in the switch statement");
					return false;
			}

			if (button != null)
			{
				if (button.FindElement(By.XPath(".//img"), 1) != null)
				{
					button.Click();
					button.Click();
					return true;
				}
				Report.Error("Image was not found: " + code);
				return false;

			}
			else
			{
				Report.Error("Button was not found: " + code);
				return false;
			}

			return false;
		}

		public bool WaitForDocumentOptionsPopup(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var Popup = this.containerElement.FindElement(By.XPath(".//div[@id='doc-options-panel']"), 1);
				if (Popup != null)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;

		}


		public bool SetOption(string option, bool check)
		{
			Delay.Seconds(1);
			var optionsList = this.containerElement.FindElements(By.XPath(".//input[@type='checkbox']"));

			switch (option)
			{
				case "edit":
					var edit = optionsList.FirstOrDefault(x => x.GetAttribute("id").ToLower().Contains("edit"));
					if (edit != null)
					{
						edit.Check(check);
						Delay.Seconds(1);
						return edit.Checked() == check;
					}
					else
					{
						Report.Error("Eidt option was not found");
					}

					return false;
				case "show translations":
					var showmissing =
						optionsList.FirstOrDefault(x => x.GetAttribute("id").ToLower().Contains("showmissing"));
					if (showmissing != null)
					{
						showmissing.Check(check);
						return showmissing.Checked() == check;
					}

					return false;
				case "show datacodes":
					var datacodes =
						optionsList.FirstOrDefault(x => x.GetAttribute("id").ToLower().Contains("datacodes"));
					if (datacodes != null)
					{
						datacodes.Check(check);
						return datacodes.Checked() == check;
					}

					return false;
				default:
					Report.Info("no valid option has been supplied");
					return false;
			}
		}

		public bool ClickCloseDocumentOptionsPopup()
		{
			var close = this.containerElement.FindElement(
				By.XPath(".//label[text()='Options']/following-sibling::img[@title='Close' and @alt='Close']"), 1);
			if (close != null)
			{
				return close.TryClick();
			}

			return false;
		}

		public bool ClickLeftMenuSection(string section, string leftRightDouble = "left")
		{
			var listOfSections = this.containerElement.FindElements(By.XPath("//ul[@id='sectionActionList']/li/span"), 2);
			var matchingSection = listOfSections.FirstOrDefault(x => x.GetValue() == section);
			if (matchingSection == null)
			{
				Report.Info("Section was not found");
				return false;
			}

			switch (leftRightDouble.ToLower())
			{
				case "left":
					return matchingSection.TryClick();
				case "right":
					matchingSection.RightClick();
					return true;
				case "double":
					matchingSection.DoubleClick();
					return true;
				default:
					throw new Exception("Must provide valid button to click: left, right or double");

			}
		}

		public bool DoubleClickCategoryToEdit(string category)
		{
			var listOfCategories = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[contains(@title, '" + category + "')]//span"), 30);
			var matchingCategories = listOfCategories.Where(x => x.GetValue() == category).ToList();
			var matchingCategory = listOfCategories.FirstOrDefault(x => x.GetValue() == category);
			if (matchingCategory == null)
			{
				Report.Info("Category was not found");
				return false;
			}
			Actions action = new Actions(SeleniumBrowser.WebBrowser);
			action.MoveToElement(matchingCategory).Build().Perform();
			matchingCategory.TryClick();
			Delay.Seconds(1);
			//nb, double click does not work so using 2 clicks

			matchingCategory.Click();
			matchingCategory.Click();
			Delay.Seconds(5);
			Report.Screenshot();
			var editScreen = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//div[@id='koPopup' and not(contains(@style,'display: none;'))]"), 2);
			if (editScreen != null)
			{
				return true;
			}
			else
			{
				Report.Info("Popup was not found.");
			}


			return false;
		}

		public string getCategoryValue(string category)
		{
			var listOfCategories = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//table[contains(@title, '" + category + "')]//span"), 30);
			var matchingCategories = listOfCategories.Where(x => x.GetValue() == category).ToList();
			var matchingCategory = listOfCategories.FirstOrDefault(x => x.GetValue() == category);
			if (matchingCategory == null)
			{
				Report.Info("Category was not found");
				return null;
			}
			Actions action = new Actions(SeleniumBrowser.WebBrowser);
			action.MoveToElement(matchingCategory).Build().Perform();
			matchingCategory.TryClick();
			Delay.Seconds(1);
			//nb, double click does not work so using 2 clicks

			matchingCategory.Click();
			matchingCategory.Click();
			Delay.Seconds(5);
			Report.Screenshot();
			ValueEditor thisValueEditor = new ValueEditor();
			return thisValueEditor.GetSelectedValue();

		}
	}

	class GraphicEditor : BaseObject
	{
		public const string BasePath = "//div[@id='koPopup']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }


		public bool SelectGraphic(string graphicName)
		{
			for (int i = 0; i < 5; i++)
			{
				try
				{
					var Graphics = this.containerElement.FindElements(By.XPath("//div[@id='subsectionGrphEditor']//table//img"));

					var matchingGraphic =
						Graphics.FirstOrDefault(x => x.GetAttribute("title").ToLower().Contains(graphicName.ToLower()));

					if (matchingGraphic != null)
					{
						return matchingGraphic.TryClick();
					}

				}
				catch (Exception e)
				{
					Report.Info("Exception was logged: " + e.Message);
				}

				Delay.Seconds(1);

			}

			return false;

		}

		public bool ClickButton(string buttonName)
		{
			var Buttons = this.containerElement.FindElements(By.XPath("//div[@id='koPopup']//input"));
			IWebElement MatchingButton;
			switch (buttonName.ToLower())
			{
				case "save":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetAttribute("id") == "btnSave_GRPH");
					break;
				case "clear":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetAttribute("id") == "btnClear_GRPH");
					break;
				case "cancel":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetAttribute("id") == "btnCancel_GRPH");
					break;
				case "previous":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetAttribute("id") == "edit-prev-ko");
					break;
				case "next":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetAttribute("id") == "edit-next-ko");
					break;
				case "upload":
					MatchingButton = Buttons.FirstOrDefault(x => x.GetValue().ToLower().Trim() == "upload");
					break;
				default:
					Report.Error("Provide valid button name");
					return false;

			}

			return MatchingButton.TryClick();
		}
	}

	class CurrentDocument : BaseObject
	{
		public const string BasePath = "//form[@id='Form1']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Current Document"))
				{
					try
					{
						SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					}
					catch (Exception e)
					{
						Report.Info("Problems with maximising");
					}
					if (!GeneralUtilities.StudioWaitForSpinner(120))
					{
						throw new Exception("Spinner is still showing");
					}
					Report.Success("Found window containing title: Current Document");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public string GetAlertText(string searchText)
		{
			//Putting this in because standard get alert functionality does not work in this page.
			if (!SeleniumBrowser.Alert.WaitForAlert(10))
			{
				SeleniumBrowser.Alert.ReloadAlert(searchText);
			}
			if (!SeleniumBrowser.Alert.WaitForAlert())
			{
				return null;
			}
			string alertText = SeleniumBrowser.Alert.GetText();
			Report.Screenshot();
			SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
			return alertText;
		}

		public bool SetCheckBox(string name, bool setChecked)
		{
			Report.Info("Beginning set checkbox: " + name);
			var checkboxes = SeleniumBrowser.WebBrowser.FindElements(By.XPath("//input[@type='checkbox']"));
			IWebElement matchingElement;
			switch (name.ToLower())
			{
				case "authorized":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "ucProdAuth_chkAuth");
					break;
				case "apply":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "ucProdAuth_chkAllSubformatAuthorize");
					break;
				case "queue":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkQueue");
					break;
				case "clear":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkClearRFR");
					break;
				case "do not unauthorize":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkDoNotUnauthorize");
					break;
				case "display revision marking":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkRevMarking");
					break;
				case "suppress":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkShowTradeSecInfo");
					break;
				case "hide alias":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkHideAlias");
					break;
				default:
					Report.Error("Please provide a valid checkbox option. You sent: " + name);
					return false;
			}

			if (matchingElement != null)
			{
				try
				{
					matchingElement.Check(setChecked);
					return true;
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
					return false;
				}

			}
			else
			{
				Report.Error("Checkbox could not be found. You sent: " + name);
				return false;
			}
		}

	}

	class PDEditPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Edit Toolbar"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Edit Toolbar");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool SetCheckBox(string name, bool setChecked)
		{
			try
			{
				var labels = this.containerElement.FindElements(By.XPath(".//label[(./input[@type='checkbox'])]"));
				var matchingLabel = labels.FirstOrDefault(x => x.GetValue().Trim() == name);
				if (matchingLabel != null)
				{
					var matchingInput = matchingLabel.FindElement(By.XPath(".//input[@type='checkbox']"));
					matchingInput.Check(setChecked);
					return matchingInput.Checked(setChecked);
				}
				else
				{
					Report.Info("No matching label has been found for: " + name);
					return false;
				}

			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return false;
			}

		}

		public bool ClickSave()
		{
			for (int i = 0; i < 5; i++)
			{
				try
				{
					if (this.containerElement.FindElement(By.XPath(".//input[@id='btnSave']"), 10).TryClick())
					{
						return true;
					}
					else
					{
						Delay.Seconds(1);
					}
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
					return false;
				}
			}

			if (SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='btnSave']"), 10).TryClick())
			{
				return true;
			}

			return false;

		}

		public bool ClickCancel()
		{
			try
			{
				return this.containerElement.FindElement(By.XPath(".//input[@id='btnCancel']")).TryClick();
			}
			catch (Exception e)
			{
				return false;
			}

		}

	}

	class ApplyRulesPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Delay.Seconds(2);
			Report.Info("Wait for apply load rules page");
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Apply Rules"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Apply Rules");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		/*
		public bool WaitForSpinner()
		{
			try
			{

				var spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[id='progress_proc_img' ]"), 2);
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
		*/

		public bool WaitForSpinner(int secondsToWait = 120)
		{
			try
			{
				for (int i = 0; i < secondsToWait; i++)
				{
					var spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
					if (!spinner.Any(x => x.Displayed))
					{
						Report.Info("Waited " + i + " cycles....");
						return true;
					}
					Delay.Seconds(Delay.SpeedFactor * 1);
				}
				Report.Info("Waited " + secondsToWait + " cycles....");
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		//All Rules, Rule Group, Single Rule
		public bool SetApplyOption(string name)
		{
			try
			{
				var radios = this.containerElement.FindElements(By.XPath(".//table[@id='tblApply']//input[@type='radio']"));
				IWebElement matchingRadio;
				switch (name.ToLower())
				{
					case "all rules":
						matchingRadio = radios.FirstOrDefault(x => x.GetAttribute("id") == "optApplyAllRules");
						break;
					case "rule group":
						matchingRadio = radios.FirstOrDefault(x => x.GetAttribute("id") == "optApplyRuleGroup");
						break;
					case "single rule":
						matchingRadio = radios.FirstOrDefault(x => x.GetAttribute("id") == "optApplyRule");
						break;
					default:
						Report.Error("You must supply a valid rule option. You supplied: " + name);
						return false;
				}

				return matchingRadio.TryClick();
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return false;
			}

		}

		//All Products, Product Group
		public bool SetApplyToOption(string name)
		{
			try
			{
				var radios = this.containerElement.FindElements(By.XPath(".//table[@id='tblTo']//input[@type='radio']"));
				IWebElement matchingRadio;
				switch (name.ToLower())
				{
					case "all products":
						matchingRadio = radios.FirstOrDefault(x => x.GetAttribute("id") == "optToAllProducts");
						break;
					case "product group":
						matchingRadio = radios.FirstOrDefault(x => x.GetAttribute("id") == "optToProductGroup");
						break;
					default:
						Report.Error("You must supply a valid apply to option. You supplied: " + name);
						return false;
				}

				return matchingRadio.TryClick();
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return false;
			}

		}

		public bool EnterInputSingleRule(string sInput)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='ucSelProductGroup_cmdSelect']"), 2);
			if (input != null)
			{
				input.EnterText(sInput);
				return input.GetValue() == sInput;
			}
			else
			{
				Report.Error("Did not find input to enter");
				return false;
			}
		}

		//update revision, email rule report, apply to ghs regions, skip report generation
		public bool SetCheckBox(string name, bool setChecked)
		{
			var checkboxes = this.containerElement.FindElements(By.XPath(".//table[@id='tblUpdateRevision']//input"));
			IWebElement matchingElement;
			switch (name.ToLower())
			{
				case "update revision":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkUpdateRevision");
					break;
				case "email rule report":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkEmailRuleReport");
					break;
				case "apply to ghs regions":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkApplyRegional");
					break;
				case "skip report generation":
					matchingElement = checkboxes.FirstOrDefault(x => x.GetAttribute("id") == "chkSkipReportGeneration");
					break;
				default:
					Report.Error("Please provide a valid checkbox option. You sent: " + name);
					return false;
			}

			if (matchingElement != null)
			{
				matchingElement.Check(setChecked);
				return matchingElement.Checked(setChecked);
			}
			else
			{
				Report.Error("Checkbox could not be found. You sent: " + name);
				return false;
			}
		}



		public bool EnterInputProductGroup(string sInput)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='ucSelProductGroup_txtProdGroup']"), 2);
			if (input != null)
			{
				input.EnterText(sInput);
				return input.GetValue() == sInput;
			}
			else
			{
				Report.Error("Did not find input to enter");
				return false;
			}
		}

		public bool ClickSingleRuleEllipsis()
		{
			var srEllipsis = this.containerElement.FindElement(By.XPath(".//input[@id='ucSelRule_cmdSelect']"), 2);
			if (srEllipsis != null)
			{
				return srEllipsis.TryClick();
			}
			else
			{
				Report.Error("Did not find single rule ellipsis to click");
				return false;
			}

		}

		public bool ClickRuleGroupEllipsis()
		{
			var rgEllipsis = this.containerElement.FindElement(By.XPath(".//input[@id='ucSelRuleGroup_cmdSelect']"), 2);
			if (rgEllipsis != null)
			{
				return rgEllipsis.TryClick();
			}
			else
			{
				Report.Error("Did not find rule group ellipsis to click");
				return false;
			}

		}

		public bool ClickRuleGroupCommandSwitch()
		{
			var rgCommandSwitch = this.containerElement.FindElement(By.XPath(".//input[@id='ucSelRuleGroup_cmdSwitch']"), 2);
			if (rgCommandSwitch != null)
			{
				return rgCommandSwitch.TryClick();
			}
			else
			{
				Report.Error("Did not find rule group command switch to click");
				return false;
			}

		}

		public bool ClickButton(string name)
		{

			for (int i = 0; i < 60; i++)
			{
				try
				{
					var buttonList = this.containerElement.FindElements(By.XPath(".//table[@id='Table2']//a"));

					IWebElement matchingButton;

					switch (name.ToLower())
					{
						case "preview":
							matchingButton = buttonList.FirstOrDefault(x => x.GetAttribute("id") == "lnkPreview");
							break;
						case "apply":
							matchingButton = buttonList.FirstOrDefault(x => x.GetAttribute("id") == "lnkApply");
							break;
						case "preview in word":
							matchingButton = buttonList.FirstOrDefault(x => x.GetAttribute("id") == "lnkPreviewInWord");
							break;
						case "close":
							matchingButton = buttonList.FirstOrDefault(x => x.GetAttribute("id") == "lnkClose");
							break;
						default:
							Report.Error("You must provide a valid button name. You supplied: " + name);
							return false;
					}

					if (matchingButton != null)
					{
						if (matchingButton.TryClick())
						{
							Delay.Seconds(2);
							return true;
						}
						else
						{
							Report.Info("Failed to click button although it was found");
						}

					}
					else
					{
						Report.Info("No matching buttons found");
					}

				}
				catch (Exception e)
				{
					Report.Info("List of buttons not found");
				}
				Delay.Seconds(1);
			}


			return false;
		}


	}

	class SelectRulesPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Select Rule"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select Rule");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				if (this.WaitForClickFilterButton(30))
				{
					return true;
				}

			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool WaitForClickFilterButton(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var button = this.containerElement.FindElement(By.XPath(".//a[@id='Selectrecord1_lnkFilter']"), 2);
				if (button != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;

		}

		public bool ClickFilterButton()
		{
			var button = this.containerElement.FindElement(By.XPath(".//a[@id='Selectrecord1_lnkFilter']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find single button to click");
				return false;
			}

		}

		public bool SelectTopRule()
		{
			var rowList =
				this.containerElement.FindElements(
					By.XPath(".//table[@id='Selectrecord1_grdSR']//tr[contains(@id, 'record')]"));
			if (rowList.Count > 0)
			{
				return rowList.First().TryClick();
			}

			return false;
		}


	}

	class SelectRulesFilter : BaseObject
	{
		public const string BasePath = "//table[@id='Selectrecord1_tblFilter']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool SelectFromSelectBox(string selectBox, string value)
		{
			var listOfSelects = this.containerElement.FindElements(By.XPath(".//select"));
			IWebElement matchingSelect;
			switch (selectBox.ToLower())
			{
				case "max records":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl02_ddlFilterType");
					break;
				case "rule id":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl03_ddlFilterType");
					break;
				case "rule name":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl04_ddlFilterType");
					break;
				case "type":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl05_ddlFilterType");
					break;
				default:
					Report.Error("Please provide valid select box name. You provided: " + selectBox);
					return false;
			}

			if (matchingSelect == null)
			{
				Report.Error("No matching select was found");
				return false;
			}

			try
			{
				matchingSelect.Select(value);
			}
			catch (Exception e)
			{
				Report.Error("Found select box but unable to select option: " + value);
				return false;
			}

			return matchingSelect.SelectedOption() == value;
		}

		public bool EnterInTextBox(string textBox, string value)
		{
			var listOfSelects = this.containerElement.FindElements(By.XPath(".//input"));
			IWebElement matchingInput;
			switch (textBox.ToLower())
			{
				case "max records":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl02_txtFilter");
					break;
				case "rule id":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl03_txtFilter");
					break;
				case "rule name":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl04_txtFilter");
					break;
				case "type":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "Selectrecord1_grdFilters_ctl05_txtFilter");
					break;
				default:
					Report.Error("Please provide valid select box name. You provided: " + textBox);
					return false;
			}
			matchingInput.EnterText(value);
			return matchingInput.GetValue() == value;
		}

		public bool EnterRuleNameFilter(string sInput)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_grdFilters_ctl04_txtFilter']"), 2);
			if (input != null)
			{
				input.EnterText(sInput);
				return input.GetValue() == sInput;
			}
			else
			{
				Report.Error("Did not find input to enter");
				return false;
			}
		}

		public bool ClickApply()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_cmdApply']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}

		}

		public bool ClickCancel()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_btnCancel']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public bool ClickClear()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_cmdClear']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}
	}
	class ProductAttributePage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Report.Info("Beginning wait for product attribute page.");
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Product Attribute Screen"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Product Attribute Screen");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return this.WaitForFilterButtonLoad();
			}

			return false;
		}

		public bool WaitForFilterButtonLoad()
		{
			for (int i = 0; i < 30; i++)
			{
				var linkToClick = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_lnkFilter']"), 2);

				if (linkToClick.Displayed)
				{
					return true;
				}

				Delay.Seconds(1);
			}

			return false;
		}

		public bool ClickToolbarItem(string toolbarItem)
		{
			IWebElement linkToClick = null;
			switch (toolbarItem.ToLower())
			{
				case "filter":
					linkToClick = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_lnkFilter']"), 2);
					break;
				case "new":
					linkToClick = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_cmdNew']"), 2);
					break;
				case "edit":
				case "editselected":
					linkToClick = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_cmdEdit']"), 2);
					break;
				case "delete":
				case "deleteSelected":
					linkToClick = this.containerElement.FindElement(By.XPath(".//a[@id='AttributesGrid_cmdDelete']"), 2);
					break;
				default:
					Report.Info("You have not provided a valid toolbar item to click.");
					return false;
			}

			if (linkToClick == null)
			{
				Report.Info("No link was found");
				return false;
			}
			return linkToClick.TryClick();
		}

		public int getRecordCount()
		{
			var spanCount = this.containerElement.FindElement(By.XPath(".//span[@id='AttributesGrid_litRecordCount']"), 2);
			if (spanCount == null)
			{
				Report.Info("Record count was not found");
				return -1;
			}
			else
			{
				try
				{
					string itemCount = spanCount.GetValue();
					return Convert.ToInt16(itemCount.Substring(0, itemCount.IndexOf(" ")));
				}
				catch (Exception e)
				{
					Report.Info("Failed to extract a number from: " + spanCount.GetValue());
					return -1;
				}

			}
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}


		public void ClickClose()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public List<string> GetAliasSubsectionData()
		{
			return SeleniumBrowser.WebBrowser
				.FindElements(By.CssSelector("#lbData > option"), 2).ToList()
				.Select(x => x.GetValue()).ToList();
		}

		public bool ClickAliasSubsectionOption(string option)
		{
			var listOfSections = this.containerElement.FindElements(By.XPath("//div[@id='AttributesGrid_divSRData']//table//tr//td"), 2);
			var matchingSection = listOfSections.FirstOrDefault(x => x.GetValue() == option);
			if (matchingSection == null)
			{
				Report.Info("Option was not found");
				return false;
			}
			return matchingSection.TryClick();
		}
	}

	class ProductAttributesFilter : BaseObject
	{
		public const string BasePath = "//table[@id='AttributesGrid_tblSelectRecord']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool SelectFromSelectBox(string selectBox, string value)
		{
			Report.Info("Select from select box: " + selectBox + " value: " + value);
			var listOfSelects = this.containerElement.FindElements(By.XPath(".//select"));
			IWebElement matchingSelect;
			switch (selectBox.ToLower())
			{
				case "code":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl02_ddlFilterType");
					break;
				case "description":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl03_ddlFilterType");
					break;
				case "usage type":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl04_ddlFilterType");
					break;
				default:
					Report.Error("Please provide valid select box name. You provided: " + selectBox);
					return false;
			}

			if (matchingSelect == null)
			{
				Report.Error("No matching select was found");
				return false;
			}

			try
			{
				matchingSelect.Select(value);
			}
			catch (Exception e)
			{
				Report.Error("Found select box but unable to select option: " + value);
				return false;
			}

			return matchingSelect.SelectedOption() == value;
		}

		public bool EnterInTextBox(string textBox, string value)
		{
			var listOfInputs = this.containerElement.FindElements(By.XPath(".//input"));
			IWebElement matchingInput;
			switch (textBox.ToLower())
			{
				case "code":
					matchingInput = listOfInputs.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl02_txtFilter");
					break;
				case "description":
					matchingInput = listOfInputs.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl03_txtFilter");
					break;
				case "usage type":
					matchingInput = listOfInputs.FirstOrDefault(x =>
						x.GetAttribute("id") == "AttributesGrid_grdFilters_ctl04_txtFilter");
					break;

				default:
					Report.Error("Please provide valid input name. You provided: " + textBox);
					return false;
			}

			matchingInput.EnterText(value);
			return matchingInput.GetValue() == value;
		}


		public bool ClickApply()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='AttributesGrid_cmdApply']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}

		}

		public bool ClickCancel()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='AttributesGrid_btnCancel']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public bool ClickClear()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='AttributesGrid_cmdClear']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}


	}

	class DocumentQueuePage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Document Queue"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Document Queue");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool ClickFilterButton()
		{
			var button = this.containerElement.FindElement(By.XPath(".//a[@id='DocumentQueue_lnkFilter']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				button = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//a[@id='DocumentQueue_lnkFilter']"), 2);
				if (button != null)
				{
					return button.TryClick();
				}
				else
				{
					Report.Error("Did not find single button to click");
					return false;
				}
			}

		}

		public List<Document> GetAllDocuments()
		{
			List<Document> DocumentList = new List<Document>();

			var rowList =
				SeleniumBrowser.WebBrowser.FindElements(
					By.XPath(".//table[@id='DocumentQueue_grdSR']//tr[contains(@id, 'DocumentQueue')]"));

			List<string> documentQueueHeaders = this.GetDocumentQueueTableHeaders();

			List<string> propertiesInDocument = new Document().GetType().GetProperties().Select(x => x.Name).ToList();

			if (documentQueueHeaders.Count == 0)
			{
				Report.Error("Unable to get document queue headers");
				return DocumentList;
			}

			if (propertiesInDocument.Count == 0)
			{
				Report.Error("Unable to get property headers for Document object");
				return DocumentList;
			}


			foreach (var row in rowList)
			{
				Document thisDocument = new Document();
				for (int i = 0; i < documentQueueHeaders.Count; i++)
				{
					//properties in Document class
					string currentHeader = documentQueueHeaders[i];

					if (currentHeader == @"Product\Alias")
					{
						currentHeader = "ProductOrAlias";
					}
					if (!propertiesInDocument.Select(x => x.ToLower().Replace(" ", string.Empty)).Contains(currentHeader.ToLower().Replace(" ", string.Empty)))
					{
						Report.Info("Header: " + currentHeader + " is not in the Document class");
					}
					else
					{
						string thisPropertyName = propertiesInDocument.FirstOrDefault(x =>
							x.ToLower().Replace(" ", string.Empty) == currentHeader.ToLower().Replace(" ", string.Empty));


						try
						{
							string valueToAdd = row.FindElement(By.XPath(".//td[" + (i + 2).ToString() + "]")).GetValue();
							var thisProperty = thisDocument.GetType().GetProperty(thisPropertyName);

							thisProperty.SetValue(thisDocument, valueToAdd);

							//Report.Info("Added value: " + valueToAdd + " to property: " + currentHeader);

						}
						catch (Exception e)
						{
							Report.Error("Error adding Document property: " + currentHeader + ": " + e.Message);
						}

					}
				}
				DocumentList.Add(thisDocument);
			}

			return DocumentList;
		}

		public List<string> GetDocumentQueueTableHeaders()
		{
			try
			{
				var headerRow =
					this.containerElement.FindElement(
						By.XPath(".//table[@id='DocumentQueue_grdSR']//tr[contains(@class, 'ColHeader')]"));
				return headerRow.FindElements(By.XPath(".//td//a")).Select(x => x.GetValue()).ToList();
			}
			catch (Exception e)
			{
				Report.Error("No header row was found");
				return new List<string>();
			}


		}

		public bool SelectTopItem()
		{
			var rowList =
				this.containerElement.FindElements(
					By.XPath(".//table[@id='DocumentQueue_grdSR']//tr[contains(@id, 'DocumentQueue')]"));
			if (rowList.Count > 0)
			{
				return rowList.First().TryClick();
			}

			return false;
		}

		public bool CheckSelectAllCheckbox()
		{
			var checkbox = this.containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_grdSR_ctl02_chkCheckAll']"), 2);
			if (checkbox != null)
			{
				checkbox.Check(true);
				Delay.Seconds(1);
				checkbox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@id='DocumentQueue_grdSR_ctl02_chkCheckAll']"), 2);
				return checkbox.Checked();
			}
			else
			{
				Report.Error("Did not find checkbox to click");
				return false;
			}
		}

		public bool ClickDeleteSelected()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='btnDelete']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public bool ClickCloneSelectedRow()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='btnClone']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public bool ClickProcessDocuments()
		{
			Report.Info("Beginning click process documents");
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='btnProcessToPublish']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public void ClickClose()
		{
			SeleniumBrowser.WebBrowser.Close();
		}


	}

	public class Document
	{
		public string Item { get; set; }
		public string Status { get; set; }
		public string ProductOrAlias { get; set; }
		public string Generic { get; set; }
		public string Plant { get; set; }
		public string Format { get; set; }
		public string Subformat { get; set; }
		public string Language { get; set; }
		public string DocType { get; set; }
		public string Authorized { get; set; }
		public string FormatAuthorization { get; set; }
		public string FormulaAuthorization { get; set; }
		public string ClearRFR { get; set; }
		public string DisplayRevs { get; set; }
		public string DateAdded { get; set; }

	}

	class SelectDocumentQueueFilter : BaseObject
	{
		public const string BasePath = "//table[@id='DocumentQueue_tblFilter']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool SelectFromSelectBox(string selectBox, string value)
		{
			Report.Info("Select from select box: " + selectBox + " value: " + value);
			var listOfSelects = this.containerElement.FindElements(By.XPath(".//select"));
			IWebElement matchingSelect;
			switch (selectBox.ToLower())
			{
				case "max records":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl02_ddlFilterType");
					break;
				case "item":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl03_ddlFilterType");
					break;
				case "status":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl04_ddlFilterType");
					break;
				case @"product\alias":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl05_ddlFilterType");
					break;
				case "generic":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl06_ddlFilterType");
					break;
				case "plant":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl07_ddlFilterType");
					break;
				case "format":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl08_ddlFilterType");
					break;
				case "subformat":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl09_ddlFilterType");
					break;
				case "language":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl10_ddlFilterType");
					break;
				case "doc type":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl11_ddlFilterType");
					break;
				case "authorized":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl12_ddlFilterType");
					break;
				case "format authorization":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl13_ddlFilterType");
					break;
				case "formula authorization":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl14_ddlFilterType");
					break;
				case "clear rfr":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl15_ddlFilterType");
					break;
				case "display revs":
					matchingSelect = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl16_ddlFilterType");
					break;
				default:
					Report.Error("Please provide valid select box name. You provided: " + selectBox);
					return false;
			}

			if (matchingSelect == null)
			{
				Report.Error("No matching select was found");
				return false;
			}

			try
			{
				matchingSelect.Select(value);
			}
			catch (Exception e)
			{
				Report.Error("Found select box but unable to select option: " + value);
				return false;
			}

			return matchingSelect.SelectedOption() == value;
		}

		public bool EnterInTextBox(string textBox, string value)
		{
			var listOfSelects = this.containerElement.FindElements(By.XPath(".//input"));
			IWebElement matchingInput;
			switch (textBox.ToLower())
			{
				case "max records":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl02_txtFilter");
					break;
				case "item":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl03_txtFilter");
					break;
				case "status":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl04_txtFilter");
					break;
				case @"product\alias":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl05_txtFilter");
					break;
				case "generic":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl06_txtFilter");
					break;
				case "plant":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl07_txtFilter");
					break;
				case "format":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl08_txtFilter");
					break;
				case "subformat":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl09_txtFilter");
					break;
				case "language":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl10_txtFilter");
					break;
				case "doc type":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl11_txtFilter");
					break;
				case "authorized":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl12_txtFilter");
					break;
				case "format authorization":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl13_txtFilter");
					break;
				case "formula authorization":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl14_txtFilter");
					break;
				case "clear rfr":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl15_txtFilter");
					break;
				case "display revs":
					matchingInput = listOfSelects.FirstOrDefault(x =>
						x.GetAttribute("id") == "DocumentQueue_grdFilters_ctl16_txtFilter");
					break;

				default:
					Report.Error("Please provide valid select box name. You provided: " + textBox);
					return false;
			}


			matchingInput.EnterText(value);
			return matchingInput.GetValue() == value;
		}

		public bool SelectDateAdded(int yearFrom, int monthFrom, int dayFrom, int yearTo, int monthTo, int dayTo)
		{
			if (this.ClickDatePicker())
			{
				SelectDateRangePage thisSelectDateRangePage = new SelectDateRangePage();
				if (thisSelectDateRangePage.Wait_for_load())
				{
					if (thisSelectDateRangePage.SelectDateFrom(dayFrom, monthFrom, yearFrom))
					{
						if (thisSelectDateRangePage.SelectDateTo(dayTo, monthTo, yearTo))
						{
							thisSelectDateRangePage.ClickOK();
							this.Wait_for_load();
							try
							{
								var dateInput = this.containerElement.FindElement(
									By.XPath(".//input[@id='DocumentQueue_grdFilters_ctl17_ucDateRange_txtDateRange']"));
								string dateFromTo = dateInput.GetValue();
								string dateFrom = dateFromTo.Split(new string[] { " - " }, StringSplitOptions.None)[0];
								string dateTo = dateFromTo.Split(new string[] { " - " }, StringSplitOptions.None)[1];

								DateTime dtDateFrom = Convert.ToDateTime(dateFrom);
								DateTime dtDateTo = Convert.ToDateTime(dateTo);

								DateTime dtExpectedDateFrom = new DateTime(yearFrom, monthFrom, dayFrom);
								DateTime dtExpectedDateTo = new DateTime(yearTo, monthTo, dayTo);

								return (dtDateFrom.Date == dtExpectedDateFrom.Date &&
										dtDateTo.Date == dtExpectedDateTo.Date);
							}
							catch (Exception e)
							{
								return false;
							}

						}
					}
				}
			}

			return false;
		}

		public bool ClickDatePicker()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_grdFilters_ctl17_ucDateRange_cmdSelect']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}

		}


		public bool ClickApply()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_cmdApply']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}

		}

		public bool ClickCancel()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_btnCancel']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}

		public bool ClickClear()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_cmdClear']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find button to click");
				return false;
			}
		}


	}

	class SelectDateRangePage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Select date range"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Select date range");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool StartDateClickCurrent()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='btnStartToday']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find single button to click");
				return false;
			}

		}

		public bool EndDateClickCurrent()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@id='btnEndToday']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find single button to click");
				return false;
			}

		}

		public bool ClickOK()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@type='submit' and @value='Ok']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find single button to click");
				return false;
			}

		}

		public bool ClickClear()
		{
			var button = this.containerElement.FindElement(By.XPath(".//input[@type='submit' and @value='Clear']"), 2);
			if (button != null)
			{
				return button.TryClick();
			}
			else
			{
				Report.Error("Did not find single button to click");
				return false;
			}

		}

		public bool SelectDateFrom(int day, int month, int year)
		{
			try
			{//check date supplied is valid
				try
				{
					DateTime DateToSelect = new DateTime(year, month, day);
				}
				catch (Exception e)
				{
					Report.Error("Valid date has not been supplied: " + e.Message);
					return false;
				}

				//get current selected from date
				var montYear =
					this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);

				if (montYear == null)
				{
					Report.Error("Failed to find current date from");
				}

				string sMonthYear = montYear.GetValue();
				int selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				string curMonth = sMonthYear.Split(' ')[0].Trim();
				int selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
				var nextYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearStartDate']"), 1);
				var previousYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearStartDate']"), 1);
				var nextMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
				var previousMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[1]/a"), 2);
				while (selectedYear != year)
				{
					this.Wait_for_load();
					montYear = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);
					sMonthYear = montYear.GetValue();
					selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
					nextYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearStartDate']"), 1);
					previousYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearStartDate']"), 1);
					if (selectedYear < year)
					{
						nextYearButton.TryClick();
					}
					if (selectedYear > year)
					{
						previousYearButton.TryClick();
					}
					selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				}
				while (selectedMonth != month)
				{
					this.Wait_for_load();
					montYear = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);
					sMonthYear = montYear.GetValue();
					curMonth = sMonthYear.Split(' ')[0].Trim();
					selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
					nextMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
					previousMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[1]/a"), 2);

					if (selectedMonth < month)
					{
						nextMonthButton.TryClick();
					}
					if (selectedMonth > month)
					{
						previousMonthButton.TryClick();
					}

				}

				var days = this.containerElement.FindElements(
					By.XPath(".//table[@id='calStartDate']//td[@class='Day' or @class='Weekend' or @class='Selected']"));

				IWebElement matchingDay = days.FirstOrDefault(x => Convert.ToInt16(x.GetValue().Trim()) == day);

				return matchingDay.TryClick();

			}
			catch (Exception e)
			{
				return false;
			}



		}

		public bool SelectDateTo(int day, int month, int year)
		{
			try
			{
				//check date supplied is valid
				try
				{
					DateTime DateToSelect = new DateTime(year, month, day);
				}
				catch (Exception e)
				{
					Report.Error("Valid date has not been supplied: " + e.Message);
					return false;
				}

				//get current selected from date
				var montYear =
					this.containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[2]"), 2);

				if (montYear == null)
				{
					Report.Error("Failed to find current date from");
				}

				string sMonthYear = montYear.GetValue();
				int selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				string curMonth = sMonthYear.Split(' ')[0].Trim();
				int selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
				var nextYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearEndDate']"), 1);
				var previousYearButton = this.containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearEndDate']"), 1);
				var nextMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
				var previousMonthButton = this.containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[1]/a"), 2);
				while (selectedYear != year)
				{
					if (selectedYear < year)
					{
						nextYearButton.TryClick();
					}
					if (selectedYear > year)
					{
						previousYearButton.TryClick();
					}
					selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				}
				while (selectedMonth != month)
				{
					if (selectedMonth < month)
					{
						nextMonthButton.TryClick();
					}
					if (selectedMonth > month)
					{
						previousMonthButton.TryClick();
					}
					selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
				}

				var days = this.containerElement.FindElements(
					By.XPath(".//table[@id='calEndDate']//td[@class='Day' or @class='Weekend' or @class='Selected']"));

				IWebElement matchingDay = days.FirstOrDefault(x => Convert.ToInt16(x.GetValue().Trim()) == day);

				return matchingDay.TryClick();
			}
			catch (Exception e)
			{
				return false;
			}



		}


	}

	class ProductFormulationPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Product Formulation"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Product Formulation");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool ClickButton(string button)
		{
			var varButtons = this.containerElement.FindElements(By.XPath(".//input[@type='button']"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetAttribute("title").ToLower() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		//Apply rules, EU Wizard, GHS Wizard, Regulation matrix
		public bool ClickAuthoringButton(string button)
		{
			var varButtons = this.containerElement.FindElements(By.XPath(".//span[@id='authoring-buttons']/a"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetAttribute("title").ToLower() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();

		}

		public bool ClickIDSelect()
		{
			var matchingButton = this.containerElement.FindElement(By.XPath(".//input[@id='productSelectorselProd']"), 2);
			if (matchingButton == null)
			{
				Report.Info("Failed to find button to open id select");
				return false;
			}

			return matchingButton.TryClick();
		}

		public bool ClickSubFormatSelect()
		{
			var matchingButton = this.containerElement.FindElement(By.XPath(".//input[@id='formatSubformatSelectorselFormat']"), 2);
			if (matchingButton == null)
			{
				Report.Info("Failed to find button to open subformat select");
				return false;
			}

			return matchingButton.TryClick();
		}

		public bool EnterID(string id)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='productSelectorselectProdTB']"));
			if (input == null)
			{
				Report.Info("Failed to find id input");
				return false;
			}

			input.EnterText(id);
			return input.GetValue() == id;
		}

		public void ClickClose()
		{
			SeleniumBrowser.WebBrowser.Close();
		}


	}


	class CreateComponentPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("New CAS Component"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: New CAS Component");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		//Save, Submit
		public bool ClickButton(string button)
		{
			var varButtons = this.containerElement.FindElements(By.XPath(".//input[@type='submit']"), 2);

			if (varButtons == null)
			{
				Report.Info("No buttons were found");
				return false;
			}
			var matchingButton = varButtons.FirstOrDefault(x => x.GetAttribute("value").ToLower() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			try
			{
				matchingButton.Click();
			}
			catch (Exception e)
			{

			}

			return true;

		}

		public bool WaitForCAS(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var input = this.containerElement.FindElement(By.XPath(".//input[@id='txtCASID']"), 1);
				if (input != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}

		public bool EnterCAS(string cas)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='txtCASID']"), 2);
			if (input == null)
			{
				Report.Info("Failed to find CAS input");
				return false;
			}

			input.EnterText(cas);
			return input.GetValue() == cas;
		}

		public bool EnterComponentID(string componentID)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='txtCompID']"));
			if (input == null)
			{
				Report.Info("Failed to find componentID input");
				return false;
			}

			input.EnterText(componentID);
			return input.GetValue() == componentID;
		}

		public bool EnterChemicalName(string chemicalName)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='txtChemName']"));
			if (input == null)
			{
				Report.Info("Failed to find chemical name input");
				return false;
			}

			input.EnterText(chemicalName);
			return input.GetValue() == chemicalName;
		}

		public bool EnterTradeSecretName(string tradeSelectName)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='txtTradeSecName']"));
			if (input == null)
			{
				Report.Info("Failed to find trade secret name input");
				return false;
			}

			input.EnterText(tradeSelectName);
			return input.GetValue() == tradeSelectName;
		}

		public bool AddToFormulationNowCheckboxChecked(bool check)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='chkAddToFormula']"));
			if (input.Checked() == check)
			{
				Report.Info("Add to Formulation Checkbox is already set correctly.");
				return true;
			}
			else
			{
				return input.TryClick();
			}

		}

		public bool LoadRegulationDataNowCheckboxChecked(bool check)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='chkLoadRegulation']"));
			if (input.Checked() == check)
			{
				Report.Info("Load Regulation Data Now Checkbox is already set correctly.");
				return true;
			}
			else
			{
				return input.TryClick();
			}

		}


		public void ClickClose()
		{
			SeleniumBrowser.WebBrowser.Close();
		}


	}


	class PhraseEditor : BaseObject
	{
		public const string BasePath = "//div[@id='editor-text-container']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}
			return false;

		}

		//Save, Clear, Cancel, Previous, Next
		public bool ClickButton(string button)
		{
			var varButtons = this.containerElement.FindElements(By.XPath(".//input[@type='button']"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetAttribute("title").ToLower() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public List<string> GetHeaders()
		{
			Report.Info("Beginning get headers");
			return SeleniumBrowser.WebBrowser
				.FindElements(By.XPath("//div[@id='divPhrasesFamily']/table/thead[@class='Header']/tr/td"), 2).ToList()
				.Select(x => x.GetValue()).ToList();

		}

		public bool SelectItem(string columnHeader, string value)
		{
			Report.Info("Selecting phrase: " + value + " in column: " + columnHeader);
			List<string> rawHeaders = this.GetHeaders();
			List<string> headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			int indexOfHeader = 0;
			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == columnHeader)
				{
					indexOfHeader = i + 1;
					break;
				}
			}

			var listOfColumnItems = this.containerElement
				.FindElements(By.XPath(".//tbody[@id='sortable-list2']/tr/td[" + indexOfHeader + "]"), 2).ToList();

			var sValues = listOfColumnItems.Select(x => x.GetValue().Trim()).ToList();
			var matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

			if (matchingItem == null)
			{
				Report.Info("Could not find matching item");
				return false;
			}
			else
			{

				for (int i = 0; i < 5; i++)
				{
					Report.Info("Trying to select with double click");
					listOfColumnItems = this.containerElement
						.FindElements(By.XPath(".//tbody[@id='sortable-list2']/tr/td[" + indexOfHeader + "]"), 2).ToList();

					matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);
					//matchingItem.TryClick();
					Delay.Seconds(1);
					matchingItem.DoubleClick();
					Delay.Seconds(2);
					var listOfSelectedColumnItems = this.containerElement
						.FindElements(By.XPath(".//table[@id='tblPicked']//tr/td[" + indexOfHeader + "]"), 2).ToList();

					var matchingSelectedItem = listOfSelectedColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

					if (matchingSelectedItem != null)
					{
						return true;
					}

				}
				for (int i = 0; i < 5; i++)
				{
					listOfColumnItems = this.containerElement
						.FindElements(By.XPath(".//tbody[@id='sortable-list2']/tr/td[" + indexOfHeader + "]"), 2).ToList();

					matchingItem = listOfColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);
					//matchingItem.TryClick();
					Delay.Seconds(1);
					matchingItem.Click();
					matchingItem.Click();
					Delay.Seconds(2);
					var listOfSelectedColumnItems = this.containerElement
						.FindElements(By.XPath(".//table[@id='tblPicked']/tr/td[" + indexOfHeader + "]"), 2).ToList();

					var matchingSelectedItem = listOfSelectedColumnItems.FirstOrDefault(x => x.GetValue().Trim() == value);

					if (matchingSelectedItem != null)
					{
						Report.Info("Required value is showing in selected list");
						return true;
					}

				}
				return false;
			}
		}

		public List<Phrase> GetSelectedPhrases()
		{
			Report.Info("Beginning get selected phrases");
			List<string> rawHeaders = this.GetHeaders();
			List<string> headers = rawHeaders.Select(x => x.Replace("\r\n", string.Empty).Trim()).ToList();
			Report.Info("Got " + headers.Count + " headers");
			int indexOfCode = 0;
			int indexOfText = 0;
			int indexOfType = 0;
			int indexOfNotes = 0;

			for (int i = 0; i < headers.Count; i++)
			{
				if (headers[i] == "Code")
				{
					indexOfCode = i + 1;
				}

				if (headers[i] == "Text")
				{
					indexOfText = i + 1;
				}

				if (headers[i] == "Type")
				{
					indexOfType = i + 1;
				}

				if (headers[i] == "Notes")
				{
					indexOfNotes = i + 1;
				}
			}
			var selectedRows = this.containerElement.FindElements(By.XPath(".//table[@id='tblPicked']//tr"), 2);
			List<Phrase> listOfPhrases = new List<Phrase>();
			if (selectedRows == null)
			{
				Report.Info("No selected rows are showing");
				return listOfPhrases;
			}

			foreach (var selectedPhrase in selectedRows)
			{
				Phrase thisPhrase = new Phrase();
				thisPhrase.Code = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfCode + "]"), 2).GetValue();
				thisPhrase.Text = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfText + "]"), 2).GetValue();
				thisPhrase.Type = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfType + "]"), 2).GetValue();
				thisPhrase.Notes = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfNotes + "]"), 2).GetValue();
				listOfPhrases.Add(thisPhrase);
			}

			return listOfPhrases;
		}

		public List<Phrase> GetAvailablePhrases()
		{
			List<string> headers = this.GetHeaders();
			var selectedRows = this.containerElement.FindElements(By.XPath(".//tbody[@id='sortable-list2']//tr"));
			int indexOfCode = this.GetHeaders().IndexOf("Code");
			int indexOfText = this.GetHeaders().IndexOf("Text");
			int indexOfType = this.GetHeaders().IndexOf("Type");
			int indexOfNotes = this.GetHeaders().IndexOf("Notes");
			List<Phrase> listOfPhrases = new List<Phrase>();
			foreach (var selectedPhrase in selectedRows)
			{
				Phrase thisPhrase = new Phrase();
				thisPhrase.Code = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfCode + "]"), 2).GetValue();
				thisPhrase.Text = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfText + "]"), 2).GetValue();
				thisPhrase.Type = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfType + "]"), 2).GetValue();
				thisPhrase.Notes = selectedPhrase.FindElement(By.XPath(".//td[" + indexOfNotes + "]"), 2).GetValue();
				listOfPhrases.Add(thisPhrase);
			}

			return listOfPhrases;
		}

		public bool filterSelectPhrases(string filter)
		{
			var input = this.containerElement.FindElement(By.XPath(".//input[@id='AttrEditPager_txtPhraseFilter']"), 2);

			if (input == null)
			{
				Report.Info("Filter input could not be found");
				return false;
			}

			input.EnterText(filter);
			Delay.Seconds(3);
			return input.GetValue() == filter;
		}
	}

	class ValueEditor : BaseObject
	{
		public const string BasePath = "//div[@id='koPopup']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var popupEditor = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath), 2);
				if (popupEditor != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}
			return false;

		}

		//Save, Clear, Cancel, Previous, Next
		public bool ClickButton(string button)
		{
			var varButtons = this.containerElement.FindElements(By.XPath(".//input[@type='button']"), 2);
			var matchingButton = varButtons.FirstOrDefault(x => x.GetAttribute("title").ToLower() == button.ToLower());
			if (matchingButton == null)
			{
				Report.Info("Failed to find button: " + button);
				return false;
			}

			return matchingButton.TryClick();
		}

		public string GetSelectedValue()
		{
			Report.Info("Beginning get selected value");
			var oldValue = this.containerElement.FindElement(By.XPath(".//textarea[@id='oldValue']"), 2);
			if (oldValue == null)
			{
				Report.Info("Value item was not found.");
				return "";
			}
			else
			{
				return oldValue.GetValue();
			}
		}
	}

	class AssignReassignProducts : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait = 60)
		{
			Delay.Seconds(2);
			Report.Info("Wait for assign/reassign products page");
			var urls = SeleniumBrowser.WebBrowser.WindowHandles;
			for (int i = 0; i < 30; i++)
			{
				urls = SeleniumBrowser.WebBrowser.WindowHandles;
				if (urls.Count > 1)
				{
					break;
				}

				Delay.Seconds(1);
			}

			if (urls.Count < 2)
			{
				return false;
			}

			//var current = SeleniumBrowser.WebBrowser.CurrentWindowHandle;

			foreach (var handle in urls)
			{
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Untitled Page"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Untitled Page");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				return true;
			}

			return false;
		}

		public void Close()
		{
			SeleniumBrowser.WebBrowser.Close();
		}

		public bool WaitForSpinner(int secondsToWait = 120)
		{
			try
			{
				for (int i = 0; i < secondsToWait; i++)
				{
					var spinner = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//img[@class='spinner-overlay']"), 2);
					if (!spinner.Any(x => x.Displayed))
					{
						Report.Info("Waited " + i + " cycles....");
						return true;
					}
					Delay.Seconds(Delay.SpeedFactor * 1);
				}
				Report.Info("Waited " + secondsToWait + " cycles....");
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		//Check Out, Check In
		public bool ClickButton(string name)
		{
			try
			{

				switch (name.ToLower())
				{
					case "check out":
						var checkOutButton = this.containerElement.FindElement(By.Id("btnCheckOut"), 2);
						if (checkOutButton == null)
						{
							Report.Info("Did not find check out button");
							return false;
						}
						return checkOutButton.TryClick();

					case "check in":
						var checkInButton = this.containerElement.FindElement(By.Id("btnCheckIn"), 2);
						if (checkInButton == null)
						{
							Report.Info("Did not find check in button");
							return false;
						}
						return checkInButton.TryClick();

					default:
						Report.Error("You must supply a valid button option. You supplied: " + name);
						return false;
				}
			}
			catch (Exception e)
			{
				Report.Error(e.Message);
				return false;
			}

		}

	}



	public class Phrase
	{
		public string Code { get; set; }
		public string Text { get; set; }
		public string Type { get; set; }
		public string Notes { get; set; }
	}
}

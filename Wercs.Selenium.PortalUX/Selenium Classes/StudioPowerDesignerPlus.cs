using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using iTextSharp.text.pdf.parser;
using NPOI.HSSF.Record;
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
	public const string BasePath = "//div[contains(@class, 'container')]";

	[FindsBy(How = How.XPath, Using = BasePath)]
	protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait=60)
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
				if (SeleniumBrowser.WebBrowser.SwitchTo().Window(handle).Title.Contains("Welcome"))
				{
					SeleniumBrowser.WebBrowser.Manage().Window.Maximize();
					Report.Success("Found window containing title: Welcome");
					Report.Screenshot();
					break;
				}
			}

			var frame = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//iframe"));
			SeleniumBrowser.WebBrowser.SwitchTo().Frame(frame);
			this.containerElement = SeleniumBrowser.WebBrowser.FindElement(By.XPath(BasePath));
			if (base.Wait_for_load(30))
			{
				//Context.AddToContext("BaseWindow", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				return true;
			}

			return false;
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

		public bool SelectFormat(string subformat, string format)
		{
			var tree = containerElement.FindElement(By.XPath(".//div[@id='tree']/ul"), 2);

			if (tree == null)
			{
				return false;
			}

			var results = tree.FindElement(By.XPath(".//li/span[(./span[contains(@class,'title') and starts-with(text(),'" + format + "')])]"), 2);
			if (results == null)
			{
				return false;
			}

			var allFormats = results.FindElement(By.XPath("./following-sibling::ul"), 2);
			if (allFormats == null)
			{
				return false;
			}

			var el = allFormats.FindElement(By.XPath(".//li/span[(./span[contains(@class,'title') and starts-with(text(),'" + subformat + "')])]"), 2);
			return el.TryClick();

		}

		public bool EnterSourceProduct(string sourceProduct)
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='sourceproductSelectselectProdTB']"));
			enterField.EnterText(sourceProduct);
			return (enterField.GetValue() == sourceProduct);
		}

		public bool ClickOpenFilterDialog()
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='sourceproductSelectselProd']"));
			return enterField.TryClick();
		}

		public bool ClickRefreshButton()
		{
			var enterField = containerElement.FindElement(By.XPath(".//button[contains(@class, 'refresh')]"));
			return enterField.TryClick();
		}

		public string GetSourceProductName()
		{
			var label = containerElement.FindElement(By.XPath(".//label[@id='sourceproductSelectlblProductName']"),5);
			if (label != null)
			{
				return label.GetValue().Trim();
			}

			return "";

		}

		public bool ClickContinueButton()
		{
			var enterField = containerElement.FindElement(By.XPath(".//input[@id='continueBtn']"));
			return enterField.TryClick();
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

	class StudioPowerDesignerPlusDesignMode : BaseObject
	{
		public const string BasePath = "//div[@id='main']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait=30)
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
			var aLinks = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[@id='divBtmToolbars']//a[not(contains(@style, 'none'))]"));
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
			var dataCodes = containerElement.FindElements(By.XPath(".//div[@id='divCanvasContent']//span[(./img)]"));
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
				var img = button.FindElement(By.XPath(".//img"),2);
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
			var dataCodes = containerElement.FindElements(By.XPath(".//div[@id='divCanvasContent']//td[(./span/img)]"));
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
				var Popup = containerElement.FindElement(By.XPath(".//div[@id='doc-options-panel']"), 1);
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
			var optionsList = containerElement.FindElements(By.XPath(".//input[@type='checkbox']"));

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
			var close = containerElement.FindElement(
				By.XPath(".//label[text()='Options']/following-sibling::img[@title='Close' and @alt='Close']"), 1);
			if (close != null)
			{
				return close.TryClick();
			}

			return false;
		}
	}

	class GraphicEditor:BaseObject
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
					var Graphics = containerElement.FindElements(By.XPath("//div[@id='subsectionGrphEditor']//table//img"));

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
			var Buttons = containerElement.FindElements(By.XPath("//div[@id='koPopup']//input"));
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

		public bool Wait_for_load(int secondsToWait=60)
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
			if (!SeleniumBrowser.Alert.WaitForAlert(5))
			{
				SeleniumBrowser.Alert.ReloadAlert(searchText);
			}
			if (!SeleniumBrowser.Alert.WaitForAlert())
			{
				return null;
			}
			else
			{
				string alertText= SeleniumBrowser.Alert.GetText();
				SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
				return alertText;
			}
		}

		public bool SetCheckBox(string name, bool setChecked)
		{
			var checkboxes = containerElement.FindElements(By.XPath(".//input[@type='checkbox']"));
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
					return matchingElement.Checked(setChecked);
				}
				catch (Exception e)
				{
					Report.Info(e.Message);
					return matchingElement.Checked(setChecked);
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

		public bool Wait_for_load(int secondsToWait=60)
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
				var labels = containerElement.FindElements(By.XPath(".//label[(./input[@type='checkbox'])]"));
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
			for (int i = 0 ;i < 5; i++)
			{
				try
				{
					if (containerElement.FindElement(By.XPath(".//input[@id='btnSave']"),10).TryClick())
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
				return containerElement.FindElement(By.XPath(".//input[@id='btnCancel']")).TryClick();
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

		public bool Wait_for_load(int secondsToWait=60)
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

		//All Rules, Rule Group, Single Rule
		public bool SetApplyOption(string name)
		{
			try
			{
				var radios = containerElement.FindElements(By.XPath(".//table[@id='tblApply']//input[@type='radio']"));
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
				var radios = containerElement.FindElements(By.XPath(".//table[@id='tblTo']//input[@type='radio']"));
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
			var input = containerElement.FindElement(By.XPath(".//input[@id='ucSelProductGroup_cmdSelect']"), 2);
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
			var checkboxes = containerElement.FindElements(By.XPath(".//table[@id='tblUpdateRevision']//input"));
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
			var input = containerElement.FindElement(By.XPath(".//input[@id='ucSelProductGroup_txtProdGroup']"), 2);
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
			var srEllipsis = containerElement.FindElement(By.XPath(".//input[@id='ucSelRule_cmdSelect']"),2);
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
			var rgEllipsis = containerElement.FindElement(By.XPath(".//input[@id='ucSelRuleGroup_cmdSelect']"), 2);
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
			var rgCommandSwitch = containerElement.FindElement(By.XPath(".//input[@id='ucSelRuleGroup_cmdSwitch']"), 2);
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
			try
			{
				var buttonList = containerElement.FindElements(By.XPath(".//table[@id='Table2']//a"));
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

				return matchingButton.TryClick();

			}
			catch (Exception e)
			{
				return false;
			}

		}


	}

	class SelectRulesPage : BaseObject
	{
		public const string BasePath = "//body";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool Wait_for_load(int secondsToWait=60)
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
				if (WaitForClickFilterButton(30))
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
				var button = containerElement.FindElement(By.XPath(".//a[@id='Selectrecord1_lnkFilter']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//a[@id='Selectrecord1_lnkFilter']"), 2);
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
				containerElement.FindElements(
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
			var listOfSelects = containerElement.FindElements(By.XPath(".//select"));
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
			var listOfSelects = containerElement.FindElements(By.XPath(".//input"));
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
			var input = containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_grdFilters_ctl04_txtFilter']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_cmdApply']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_btnCancel']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='Selectrecord1_cmdClear']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//a[@id='DocumentQueue_lnkFilter']"), 2);
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

			List < string > documentQueueHeaders = GetDocumentQueueTableHeaders();

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
				for (int i=0; i<documentQueueHeaders.Count; i++)
				{
					//properties in Document class
					string currentHeader = documentQueueHeaders[i];

					if (currentHeader == @"Product\Alias")
					{
						currentHeader = "ProductOrAlias";
					}
					if (!propertiesInDocument.Select(x=>x.ToLower().Replace(" ",string.Empty)).Contains(currentHeader.ToLower().Replace(" ", string.Empty)))
					{
						Report.Error("Header: " + currentHeader + " is not in the Document class");
					}
					else
					{
						string thisPropertyName = propertiesInDocument.FirstOrDefault(x =>
							x.ToLower().Replace(" ", string.Empty) == currentHeader.ToLower().Replace(" ", string.Empty));


						try
						{
							string valueToAdd = row.FindElement(By.XPath(".//td[" + (i +2).ToString() + "]")).GetValue();
							var thisProperty = thisDocument.GetType().GetProperty(thisPropertyName);

							thisProperty.SetValue(thisDocument,valueToAdd);

							Report.Info("Added value: " + valueToAdd + " to property: " + currentHeader);


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
					containerElement.FindElement(
						By.XPath(".//table[@id='DocumentQueue_grdSR']//tr[contains(@class, 'Header')]"));
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
				containerElement.FindElements(
					By.XPath(".//table[@id='DocumentQueue_grdSR']//tr[contains(@id, 'DocumentQueue')]"));
			if (rowList.Count > 0)
			{
				return rowList.First().TryClick();
			}

			return false;
		}

		public bool CheckSelectAllCheckbox()
		{
			var checkbox = containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_grdSR_ctl02_chkCheckAll']"), 2);
			if (checkbox != null)
			{
				checkbox.Check(true);
				return checkbox.Checked(true);
			}
			else
			{
				Report.Error("Did not find checkbox to click");
				return false;
			}
		}

		public bool ClickDeleteSelected()
		{
			var button = containerElement.FindElement(By.XPath(".//input[@id='btnDelete']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='btnClone']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='btnProcessToPublish']"), 2);
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
			var listOfSelects = containerElement.FindElements(By.XPath(".//select"));
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
			var listOfSelects = containerElement.FindElements(By.XPath(".//input"));
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
								var dateInput = containerElement.FindElement(
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_grdFilters_ctl17_ucDateRange_cmdSelect']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_cmdApply']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_btnCancel']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='DocumentQueue_cmdClear']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='btnStartToday']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@id='btnEndToday']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@type='submit' and @value='Ok']"), 2);
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
			var button = containerElement.FindElement(By.XPath(".//input[@type='submit' and @value='Clear']"), 2);
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
					containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);

				if (montYear == null)
				{
					Report.Error("Failed to find current date from");
				}

				string sMonthYear = montYear.GetValue();
				int selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				string curMonth = sMonthYear.Split(' ')[0].Trim();
				int selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
				var nextYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearStartDate']"), 1);
				var previousYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearStartDate']"), 1);
				var nextMonthButton = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
				var previousMonthButton = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[1]/a"), 2);
				while (selectedYear != year)
				{
					this.Wait_for_load();
					montYear = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);
					sMonthYear = montYear.GetValue();
					selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
					nextYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearStartDate']"), 1);
					previousYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearStartDate']"), 1);
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
					montYear = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[2]"), 2);
					sMonthYear = montYear.GetValue();
					curMonth = sMonthYear.Split(' ')[0].Trim();
					selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
					nextMonthButton = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
					previousMonthButton = containerElement.FindElement(By.XPath("//table[@id='calStartDate']//tr[1]//table//tr[1]/td[1]/a"), 2);

					if (selectedMonth < month)
					{
						nextMonthButton.TryClick();
					}
					if (selectedMonth > month)
					{
						previousMonthButton.TryClick();
					}

				}

				var days = containerElement.FindElements(
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
					containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[2]"), 2);

				if (montYear == null)
				{
					Report.Error("Failed to find current date from");
				}

				string sMonthYear = montYear.GetValue();
				int selectedYear = Convert.ToInt16(sMonthYear.Split(' ')[1].Trim());
				string curMonth = sMonthYear.Split(' ')[0].Trim();
				int selectedMonth = DateTime.ParseExact(curMonth, "MMMM", CultureInfo.InvariantCulture).Month;
				var nextYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkForwardOneYearEndDate']"), 1);
				var previousYearButton = containerElement.FindElement(By.XPath(".//a[@id='lnkBackOneYearEndDate']"), 1);
				var nextMonthButton = containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[3]/a"), 2);
				var previousMonthButton = containerElement.FindElement(By.XPath("//table[@id='calEndDate']//tr[1]//table//tr[1]/td[1]/a"), 2);
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

				var days = containerElement.FindElements(
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


}

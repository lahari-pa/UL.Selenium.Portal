using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes.ChooseGoodGuide
{
	class GGNewProduct : BaseObject
	{
		public const string BasePath = "//div[@id='dataEntry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public bool ClickSaveAndNext()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[(./b[contains(text(), 'Save and Next')])]"))
				.TryClick();

		}
		//Create or Copy
		public bool SelectAddProductOption(string option)
		{
			return containerElement
				.FindElement(By.XPath("//label[contains(text(), 'Add Product')]/..//label/span[contains(text(),'" + option +
				                      "')]/../input"))
				.TryClick();

		}

		public bool WaitForSection(string sectionHeader, int secondsToWait = 60)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				var addProductHeader = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div/h1"))
					.FirstOrDefault(x => x.Text.Contains(sectionHeader));
				if (addProductHeader != null)
				{
					return true;
				}
				Delay.Seconds(Delay.SpeedFactor * 1);
				counter++;
			}

			return false;
		}

		/****************  Product Identification*/

		public bool EnterProductName(string productName)
		{
			try
			{
				var input = containerElement.FindElement(
					By.XPath("//div[@class='form-group']//label[contains(text(),'Product Name')]/../..//input"));
				input.EnterText(productName);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}

			return false;
		}

		public bool ProductLineExists(string productLine)
		{
			var select = SeleniumBrowser.WebBrowser.FindElement(By.XPath(
				".//div[@class='form-group']//label[contains(text(),'Product Line/Brand')]/../..//select"));
			select.TryClick();
			if (select.FindElements(By.XPath("./option")).Select(x => x.Text).Contains(productLine))
			{
				return true;
			}

			return false;
		}

		public bool WaitForNewProductRadio(int secondsToWait) {
			
			int counter = 0;
			while (counter < secondsToWait)
			{
				var radioLabel = containerElement.FindElements(By.XPath(".//span[contains(text(), 'Create a New Product')]"));
				if (radioLabel != null)
				{
					return true;
				}
				Delay.Seconds(Delay.SpeedFactor * 1);
				counter++;
			}

			return false;

		}

		public bool SelectCategory(string category)
		{
			try
			{
				containerElement.FindElement(By.XPath("//label[contains(text(),'Category')]/../../div[@class='form-group child']//select")).Select(category);
				return true;
			}
			catch (Exception e)
			{
			}

			return false;

		}

		public bool SelectSubCategory(string subcategory)
		{
			try
			{
				containerElement.FindElement(By.XPath("//label[contains(text(),'Category')]/../../div[contains(@class,'form-group offset')]//select")).Select(subcategory);
				return true;
			}
			catch (Exception e)
			{
			}

			return false;

		}

		public string ProductIdentificationGetInfo()
		{
			try
			{
				return containerElement.FindElement(By.XPath("//div[@class='form-group']/div[@class='INFO']/p")).Text.Trim();
			}
			catch (Exception e)
			{
			}

			return "";
		}
		
		public bool SelectProductLineBrand(string productLine)
		{
			try
			{
				var select = SeleniumBrowser.WebBrowser.FindElement(By.XPath(
					".//div[@class='form-group']//label[contains(text(),'Product Line/Brand')]/../..//select"));
				select.TryClick();
				if (select.FindElements(By.XPath("./option")).Select(x => x.Text).Contains(productLine))
				{
					select.Select(productLine);
					return true;
				}
				else
				{
					SafewareReporting.Report.Info("Option does not exist in select box");
				}
			}
			catch (Exception e)
			{
				return false;
			}

			return false;
		}

		public bool AddNewProductLineBrandName(string productLine)
		{
			if (SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//a[contains(text(), 'Add new product')]")).TryClick())
			{
				if (WaitForSection("Product Line/Brand"))
				{
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[contains(text(), 'Product Line/Brand')]/following-sibling::input")).EnterText(productLine);
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[contains(text(), 'Product Line/Brand')]/following-sibling::button")).TryClick();
					SeleniumBrowser.WebBrowser.FindElement(By.XPath("//label[contains(text(), 'Product Line/Brand')]/following-sibling::a")).TryClick();
					if (WaitForSection("Product Identification"))
					{
						return true;
					}
				}
			}

			return false;
		}


		//=========== Physical Property ================//

		public bool SetPhysicalState(string state)
		{
			try
			{
				var radio = SeleniumBrowser.WebBrowser.FindElement(By.XPath(
					".//label[contains(text(),'physical state of your product')]/..//label/span[text()='" + state + "']/..//input"));
				return radio.TryClick();
			}
			catch (Exception e)
			{
			}

			return false;
		}

		public bool EnterPHValue(string value)
		{
			try
			{
				var phInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//input[@name='PH']"));
				phInput.EnterText(value);
				return true;
			}
			catch (Exception e)
			{
			}

			return false;
		}

		//=========== Marks of Distinction ==============//
			public int GetRating()
			{
				try
				{
					var score = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//text[@class='highcharts-title']/tspan"));
					return Convert.ToInt16(score.Text.Trim());
				}
				catch (Exception e)
				{
					
				}

				return -1;
			}

		public bool SetContinue(string continueYN)
		{
			try
			{
				var input = SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//label[contains(text(), 'Would you like to continue')]/..//span[text()='Yes']/..//input"));
				if (continueYN.ToLower() == "no")
				{
					input = SeleniumBrowser.WebBrowser.FindElement(
						By.XPath("//label[contains(text(), 'Would you like to continue')]/..//span[text()='No']/..//input"));
				}

				return input.TryClick();
			}
			catch (Exception e)
			{
				
			}

			return false;
		}


		// ========= Company/Brand Information ========= //
		public bool UploadFile(string documentType, string filePath)
		{
			var buttonToClick =
				containerElement.FindElement(
					By.XPath("//tr/td/label[contains(text(), '"+documentType.Trim() +"')]/../..//span[contains(@class, 'button')]"));
			if (buttonToClick != null)
			{
				if (buttonToClick.TryClick())
				{
					System.Threading.Thread.Sleep(5000);
					
					if (SeleniumUtilities.GeneralFunctions.EnterFilename(filePath))
					{
						return true;
					}
				}
			}

			return false;
		}

		// ========= UPC List ========= //

		public bool ClickAddUPC()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[contains(@data-bind, 'addUpc')]")).TryClick();
		}

		public bool ClickSaveUPC()
		{
			return SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[contains(@data-bind, 'save')]")).TryClick();
		}

		public bool InputUpcInformation(UpcInformation info)
		{
			try
			{
				
				if (info.UpcNumber.ToLower().Contains("saved as"))
				{
					var savedUPC = Context
						.GetFromContext(info.UpcNumber.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim())
						.ToString();
					info.UpcNumber = savedUPC;
				}

				if (!SetUPCValue(info.UpcNumber))
				{
					SafewareReporting.Report.Info("Failed to set upc number");
					return false;
				}

				if (!SetUPCType(info.ContainerType))
				{
					SafewareReporting.Report.Info("Failed to set container type");
					return false;
				}

				if (!SetUPCSize(info.Size))
				{
					SafewareReporting.Report.Info("Failed to set upc size");
					return false;
				}
				
				return true;
			}
			catch (Exception ex)
			{
				SafewareReporting.Report.Info(ex.Message);
				return false;
			}
		}

		public bool SetUPCValue(string upc)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[contains(@data-bind, 'upc')]"));
			if (upcInput != null)
			{
				upcInput.EnterText(upc);
				return true;
			}

			return false;
		}

		public bool SetUPCType(string type)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//select[contains(@data-bind, 'Type')]"));
			if (upcInput != null)
			{
				upcInput.Select(type);
				return true;
			}

			return false;
		}

		public bool SetUPCCheckbox(bool trueOrFalse)
		{
			try
			{
				var upcCheckbox = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[@type='checkbox' and not(@id='chkAll')]"));
				upcCheckbox.Check(trueOrFalse);
				return true;
			}
			catch (Exception e)
			{
			}

			return false;
		}
		

		public bool SetUPCSize(string size)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[contains(@data-bind, 'size')]"));
			if (upcInput != null)
			{
				upcInput.EnterText(size);
				return true;
			}

			return false;
		}

		public bool WaitForUPCAdd(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[contains(@data-bind, 'upc')]"));
					if (upcInput != null)
					{
						return true;
					}
					Delay.Seconds(1);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}
			return false;
		}

		public bool UPCGridWaitForLoad(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				try
				{
					var upcGrid = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//table[contains(@class, 'upcgrid')]"));
					if (upcGrid != null)
					{
						return true;
					}
				}
				catch (Exception e)
				{
				}
				Delay.Seconds(1);
			}

			return false;

		}

		public bool UPCGridClickButton(string button)
		{
			var buttonToClick =
				SeleniumBrowser.WebBrowser.FindElement(
					By.XPath("//table[contains(@class, 'upcgrid')]//button[(i[contains(@class, '" + button + "')])]"));
			return buttonToClick.TryClick();
		}

		public bool UPCGridSetProductName(string productName)
		{
			var upcProductName = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//input[contains(@data-bind, 'value')]"));
			if (upcProductName != null)
			{
				upcProductName.EnterText(productName);
				return true;
			}

			return false;
		}

		public bool UPCGridGoodGuide(string yesNo)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[4]/select[contains(@data-bind, 'options')]"));
			if (upcInput != null)
			{
				upcInput.Select(yesNo);
				return true;
			}

			return false;
		}

		public bool UPCGridScent(string scent)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[6]/select[contains(@data-bind, 'options')]"));
			if (upcInput != null)
			{
				upcInput.ScrollElementIntoView();
				upcInput.Select(scent);
				return true;
			}

			return false;
		}

		public bool UPCGridColour(string colour)
		{
			var upcInput = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//td[5]/select[contains(@data-bind, 'options')]"));
			if (upcInput != null)
			{
				upcInput.ScrollElementIntoView();
				upcInput.Select(colour);
				return true;
			}

			return false;
		}

		//Image, Front, Back
		public bool UPCUpload(string documentType, string filePath)
		{
			var buttonToClick = containerElement.FindElement(By.XPath("//td[7]//span[text()='Add']/../../span"));
			switch (documentType)
			{
				case "Image":
					buttonToClick = containerElement.FindElement(By.XPath("//td[7]//span[text()='Add']/../../span"));
					break;
				case "Front":
					buttonToClick = containerElement.FindElement(By.XPath("//td[8]//span[text()='Add']/../../span"));
					break;
				case "Back":
					buttonToClick = containerElement.FindElement(By.XPath("//td[9]//span[text()='Add']/../../span"));
					break;
				default:
					throw new Exception("You must provide a valid document type");
			}
			
			if (buttonToClick != null)
			{
				buttonToClick.ScrollElementIntoView();
				if (buttonToClick.TryClick())
				{
					System.Threading.Thread.Sleep(5000);

					if (SeleniumUtilities.GeneralFunctions.EnterFilename(filePath))
					{
						return true;
					}
				}
			}

			return false;
		}


		// ========= Data Acceptance ========= //
		public bool WouldYouLikeToSubmitProductInfo(string yesOrNo)
		{
			var submit = SeleniumBrowser.WebBrowser.FindElement(By.XPath(
				"//h4[contains(text(), 'submit your product information')]/..//input[@value='" + yesOrNo.ToLower() + "']"));
			return submit.TryClick();
		}

		public bool DataAcceptanceClickOK()
		{
			var buttonOK = SeleniumBrowser.WebBrowser.FindElement(By.XPath("//button[@id='cmdAcceptProduct']"));
			return buttonOK.TryClick();
		}

		// ========= Add Ingredient Functions ========= //

		public bool AddIngredient(Ingredient ingredient)
		{
			var placeholderEl = containerElement.FindElement(By.XPath(".//input[@id='txtCasNumber']"), 2);
			placeholderEl.TryClick();
			IWebElement MatchedEntry = null;
			var inputEl = containerElement.FindElement(By.XPath(".//input[@id='txtCasNumber']"), 2);
			if (ingredient.CASNumber != "" && ingredient.CASNumber != null)
			{
				inputEl.EnterText(ingredient.CASNumber);
				var searching = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				}

				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				// If no elements match this, then we will simply take the first element in the list

				var Matches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				if (Matches.Count == 0)
				{
					return false;
				}

				var MatchingCasValues = Matches.Where(x => x.FindElement(By.XPath(".//input[@id='txtCasNumber']"), 2).GetValue().Trim() == ingredient.CASNumber.Trim());

				if (MatchingCasValues.Count() == 0)
				{
					MatchedEntry = Matches.FirstOrDefault();
					ingredient.CASNumber = MatchedEntry.FindElement(By.XPath(".//a"), 2).GetValue();
					ingredient.ComponentName = MatchedEntry.FindElement(By.XPath(".//a"), 2).GetValue();
				}
				else
				{
					// In this case we have entries with matching CAS Numbers, so we should double check that our product name matches?
					if (ingredient.ComponentName == "" || ingredient.ComponentName == null)
					{
						// No Component name was specified, so we just take the first value with a matching CAS Number!
						MatchedEntry = MatchingCasValues.FirstOrDefault();
					}
					else
					{
						// Component name was defined, so just check to see if there is a match
						var matchingNames = MatchingCasValues.FirstOrDefault(x => x.FindElement(By.XPath(".//a"), 2).GetValue().Trim() == ingredient.ComponentName.Trim());
						if (matchingNames == null)
						{
							// No match was found, so just take the first entry!
							MatchedEntry = MatchingCasValues.FirstOrDefault();
						}
						else
						{
							// Matching entry was found, so taking this instead!
							MatchedEntry = matchingNames;
						}
					}
				}
			}
			else
			{
				// So in this case we want to try and find the entry by the name
				inputEl.EnterText(ingredient.ComponentName);
				Delay.Seconds(3);
				var searching = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				int i = 0;
				while (searching != null && i < 10)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					i++;
					searching = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				}

				// So, we have now searched for our CAS ingredient, so we now need to select the first 'li' tage which contains our CAS Value exactly
				// If no elements match this, then we will simply take the first element in the list
				SafewareReporting.Report.Info("Looking for perfect match.");
				var Matches = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);

				SafewareReporting.Report.Info("Matches: " + Matches.Count.ToString());

				while (Matches.FirstOrDefault().FindElement(By.XPath(".//a"), 2) == null)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					Matches = containerElement.FindElements(By.XPath(".//li[contains(@class,'ui-menu-item')]"), 2);
				}

				var MatchingNameValue = Matches.FirstOrDefault(x => x.GetValue().Trim() == ingredient.ComponentName.Trim());
				SafewareReporting.Report.Info("Got matching name value: " + MatchingNameValue);
				if (MatchingNameValue == null)
				{
					// No matching name entry was found, so we take the first one just in case we are looking for a partial match!
					MatchedEntry = Matches.FirstOrDefault();
					ingredient.CASNumber = MatchedEntry.GetValue();
					ingredient.ComponentName = MatchedEntry.GetValue();
				}
				else
				{
					MatchedEntry = MatchingNameValue;
					// We have found a match by the component name! So we should update our CAS Number field
					ingredient.CASNumber = MatchingNameValue.GetValue();
				}
			}



			// So now we simple need to try and click this element! Easy right...

			if (MatchedEntry.TryClick())
			{
				// So we have now selected the element, so we need to try and get the first 'new' entry which contains this CAS Number, and hasn't had the Percentage field filled
				var rows = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div[contains(@class,'jqgrid')]//table//tbody//tr"), 2);

				var matchingrow = rows.FirstOrDefault(x => ingredient.CASNumber.Contains(x.FindElement(By.XPath(".//td[1]"), 2).Text.Trim())&& x.FindElement(By.XPath(".//td[1]"), 2).Text.Trim().Length>0);
				if (matchingrow == null)
				{
					return false;
				}

				// So we hopefully hgave our matching row now - so lets try and get the Precentage Concentration field
				var concInput = matchingrow.FindElement(By.XPath(".//input"), 2);
				concInput.EnterText(ingredient.Percent);

				var tsInput = matchingrow.FindElement(By.XPath(".//div[@name='TradeSecret']/input[@title='No']"), 2);
				if (ingredient.TradeSecret)
				{
					tsInput = matchingrow.FindElement(By.XPath(".//div[@name='TradeSecret']/input[@title='Yes']"), 2);
				}
				tsInput.Click();

				var pdInput = matchingrow.FindElement(By.XPath(".//div[@name='TRANSP']/input[@title='No']"), 2);
				if (ingredient.PublicallyDisclosed)
				{
					tsInput = matchingrow.FindElement(By.XPath(".//div[@name='TRANSP']/input[@title='Yes']"), 2);
				}
				tsInput.Click();

				return true;
			}

			return false;
		}

	}
}

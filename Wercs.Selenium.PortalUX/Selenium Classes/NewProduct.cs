using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;


namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class NewProduct : BaseObject
	{
		// Again a pretty poor/generic ID AND CLASHES WITH FORWARD PRODUCT REGISTRATION!!!
		// but it's the best we have....
		public const string BasePath = "//div[@id='dataentry']";

		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string GetHeader()
		{
			return this.containerElement.FindElement(By.XPath(".//div[@class='product-header']/h2"), 2).Text;
		}

		public string GetInitialStatement()
		{
			return this.containerElement.FindElement(By.XPath(".//form//label[@class='control-label']"), 2).Text;
		}

		public List<string> RadioButtons()
		{
			return this.containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2).Select(x => x.Text.Trim()).ToList();
		}

		public string ErrorMessage()
		{
			return this.containerElement.FindElement(By.XPath(".//p[@class='form-error']//span"), 2).Text;
		}

		public string GetCurrentProduct()
		{
			return this.containerElement.FindElement(By.XPath(".//h2[@class='product-name']"), 2).Text.Trim();
		}

		//New, Copy or UPC
		public void SelectTypeOfProductToCreate(string Type = "New")
		{
			var option = containerElement.FindElements(By.XPath(".//form//input[@type='radio']/../span"), 2)
				.FirstOrDefault(x => x.Text.Contains(Type));
			if (option == null)
			{
				return;
			}

			option.Click();
		}

		public void CreateNewProductOrCopy(bool newProduct = true)
		{
			var option = this.containerElement.FindElements(By.XPath(".//form//label[@class='radio']"), 2).FirstOrDefault(x => x.Text.StartsWith((newProduct ? "Yes" : "No")));
			if (option == null)
			{
				return;
			}

			option.Click();
		}

		//Valid tab names: Product Type, Product Characteristics, Recipient and UPC Details, Review and Submit
		public bool WaitForTab(string TabName, int secondsToWait = 30)
		{
			int counter = 0;
			while (counter < secondsToWait)
			{
				var progWizard = containerElement.FindElement(By.XPath(".//div[@class='prog-wizard']"));
				if (progWizard != null)
				{
					var tab = containerElement.FindElements(By.XPath(".//div[contains(@class, 'progress')]//span[contains(@data-bind, 'description')]"), 2)
						.FirstOrDefault(x => x.Text.Contains(TabName));
					if (tab != null)
					{
						var ContainerDiv = tab.FindElement(By.XPath("./../../div"));
						string backGroundColour = ContainerDiv.GetCssValue("background-color");
						if (backGroundColour.Contains("255, 255, 255"))
						{
							return true;
						}
					}
				}
				Delay.Seconds(Delay.SpeedFactor * 1);
				counter++;
			}
			return false;
		}

		public bool ClickContinue()
		{
			try
			{
				var el = this.containerElement.FindElement(By.XPath(".//a[contains(@class,'continue-button')]"), 2);
				if (el == null)
				{
					return false;
				}

				el.Click();
				GeneralUtilities.Wait_for_load_finish();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string ProductName {
			get { return this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product name')]/../following-sibling::div/input"), 2).Text.Trim(); }
			set { this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product name')]/../following-sibling::div/input"), 2).EnterText(value); }
		}

	    public string ProductLineOrBrand 
	    {
		    set
			{
				var el = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'Product Line')]/../following-sibling::div//select"), 2);
				el.SelectByValue(value);
		    }

	    }

        public string ProductType
        {
            set
            {
                var el = this.containerElement.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 2);
                el.Click();
                var inputField = this.containerElement.FindElement(By.XPath("//span[contains(@class,'select2-container')]//input"), 2);
                inputField.EnterText(value);
                GeneralUtilities.Wait_for_load_finish();

				var dropDownResults = this.containerElement.FindElements(By.XPath("//span[contains(@class,'select2-container')]//ul/li"), 2);
				var ddlEl = dropDownResults.FirstOrDefault(x => x.Text.Trim() == value);
				if (ddlEl == null)
				{
					return;
				}

				ddlEl.Click();
			}
		}
	}
}

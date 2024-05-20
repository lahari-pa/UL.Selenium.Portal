using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.WebDriver.Extensions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type
{
	class AdditionalProductInformation : NewProduct
	{
		public List<string> ProductsMayBeSold {
			get
			{
				var countries = new List<string>();
				ReadOnlyCollection<IWebElement> listOfCountries = this.containerElement.FindElements(By.XPath(".//label"), 2) 
						?.FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in"))
						?.FindElements(By.XPath("../..//input"));
				
				if (listOfCountries == null)
				{
					return null;
				}
				foreach (IWebElement country in listOfCountries)
				{
					if (country.Selected)
					{
						countries.Add(country.FindElement(By.XPath("../..//label"), 2).Text);
					}
				}
				return countries;

			}
			set
			{
				foreach (string country in value)
				{

					IWebElement thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2)?.FirstOrDefault(x => x.Text.Contains("Select countries the product may be sold in")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == country);

					if (thisLabel == null)
					{
						return;
					}

					IWebElement countryInput = thisLabel.FindElement(By.XPath(".//../input"), 2);
					
					if (countryInput == null)
					{
						return;
					}
					if (!countryInput.Selected)
					{
						countryInput.Click();
					}
				}

			}
		}


		public bool ProductClassifiedUnderOSHA {
			get
			{
				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product has been classified using OSHA"))
					.FindElements(By.XPath("../following-sibling::div//label"), 2).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span"), 2).Text.Trim();
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No product has been classified using OSHA option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product has been classified using OSHA"))
					.FindElements(By.XPath("../..//label"), 2).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
			}
		}

		public bool ProductShippedDirectly {
			get
			{
				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../following-sibling::div//label"), 2).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span"), 2).Text.Trim();
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No product shipped directly option is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is shipped directly"))
					.FindElements(By.XPath("../..//label"), 2).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();
			}
		}

		public bool RetailersPrivateLabelOrBrand {
			get
			{
				IWebElement selectOption = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product"))
					.FindElements(By.XPath("../following-sibling::div//label"), 2).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span"), 2).Text.Trim();
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				IWebElement selectOption = this.ContainerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product"))
					.FindElements(By.XPath("../..//label"), 2).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool SolelyForRetailersUse {
			get
			{
				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../following-sibling::div//label"), 2).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span"), 2).Text.Trim();
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("solely for the Retailer's use"))
					.FindElements(By.XPath("../..//label"), 2).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}

		public bool IsCaliforniaCleaning {
			get
			{
				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("California's Cleaning Product"))
					.FindElements(By.XPath("../following-sibling::div//label"), 2).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span"), 2).Text.Trim();
					if (selectedOption.ToLower() == "yes")
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					throw new Exception("No California Cleaning Product value is selected");
				}
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}

				IWebElement selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("California's Cleaning Product"))
					.FindElements(By.XPath("../..//label"), 2).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


			}
		}
	}
}

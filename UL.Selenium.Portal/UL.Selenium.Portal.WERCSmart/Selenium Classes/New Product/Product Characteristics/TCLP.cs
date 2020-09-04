using System;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class TCLP : NewProduct
	{
		private IWebElement MetalHeader => this.containerElement.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

		private List<IWebElement> MetalContainers => this.MetalHeader.FindElements(By.XPath("../../following-sibling::div[not(@style='display: none;')]"), 2).ToList();

		public bool ProductHasTclp {
			get
			{
				IWebElement activeLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'TCLP')]/../following-sibling::div//label[contains(@class,'active')]"), 2);
				try
				{
					activeLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'TCLP')]/../following-sibling::div//label[contains(@class,'active')]"), 2);
				}
				catch (NoSuchElementException)
				{
					return false;
				}
				if (activeLabel == null)
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
				string selectedOption = activeLabel.FindElement(By.XPath("./span"), 2)?.Text;
				return selectedOption != null && selectedOption.ToLower().Trim() == "yes";
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}
				IWebElement matchingLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'TCLP')]/../..//input[@type='radio' and ./following-sibling::span[text()='" + valueToSet + "']]/parent::label"), 2);
				matchingLabel.TryClick();
			}
		}

		public class MetalPresence
		{
			public string Metal { get; set; }
			public string Presence { get; set; }

			public MetalPresence(string metalName, string metalPresence)
			{
				this.Metal = metalName;
				this.Presence = metalPresence;
			}
		}

		public List<MetalPresence> Metals {
			get
			{
				Report.Info("Getting list of Metal Presence information");
				var listOfMetals = new List<MetalPresence>();
				List<IWebElement> rows = this.MetalContainers;
				Report.Info("There are " + rows.Count + " Metal Presence rows displayed");
				foreach (IWebElement metalRow in this.MetalContainers)
				{
					string metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"), 2)?.Text;
					IWebElement selectedOption = metalRow.FindElements(By.XPath(".//div[@class='radio']//input"), 2)?.First(x => x.Selected);
					string metalPresence = selectedOption?.FindElement(By.XPath("../span"), 2)?.Text;
					if (metalName == null || selectedOption == null)
					{
						Report.Error("No metal presence information found for this row!");
						continue;
					}
					listOfMetals.Add(new MetalPresence(metalName, metalPresence));
				}
				return listOfMetals;
			}
			set
			{
				Report.Info(value.Count + " metals to set.");
				IWebElement header = this.MetalHeader;
				foreach (MetalPresence thisMetal in value)
				{
					IWebElement metalLabel;
					IWebElement inputLabel;
					try
					{
						metalLabel = header.FindElements(By.XPath("../../following::div//label[@class='control-label']")).FirstOrDefault(x => x.GetValue().Trim() == thisMetal.Metal);
						inputLabel = metalLabel.FindElements(By.XPath("../..//input/../span")).FirstOrDefault(x => x.Text == thisMetal.Presence);
					}
					catch (NoSuchElementException)
					{
						return;
					}

					if (inputLabel != null)
					{
						try
						{
							IWebElement metalInput = inputLabel.FindElement(By.XPath("../input"));
							Report.Info("Attempting to set metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
							metalInput.TryClick();
						}
						catch (Exception)
						{
							Report.Error("Failed to click metal: " + thisMetal.Metal + " and value: " + thisMetal.Presence);
							throw;
						}
					}
					else
					{
						throw new Exception("Cannot find input for: " + thisMetal.Metal);
					}
				}

			}
		}

		public List<string> GetAllMetalNames()
		{
			var listOfMetals = new List<string>();
			IWebElement circuit = this.MetalHeader;
			foreach (IWebElement metalRow in this.MetalContainers)
			{
				listOfMetals.Add(metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"), 2)?.Text);
			}
			return listOfMetals;
		}

		public bool WaitForMetalSection(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				IWebElement header = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div")).FirstOrDefault(x => x.Text.Contains("following metals"));
				if (header != null)
				{
					return true;
				}
				Delay.Seconds(1);
			}

			return false;
		}
	}
}

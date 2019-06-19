using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
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
				var activeLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'TCLP')]/../following-sibling::div//label[contains(@class,'active')]"), 2);
				if (activeLabel == null)
				{
					throw new Exception("No Product is Retailer's Private Label or Brand value is selected");
				}
				var selectedOption = activeLabel.FindElement(By.XPath("./span"), 2)?.Text;
				return selectedOption != null && selectedOption.ToLower().Trim() == "yes";
			}
			set
			{
				string valueToSet = "Yes";
				if (!value)
				{
					valueToSet = "No";
				}
				var matchingLabel = this.containerElement.FindElement(By.XPath(".//label[contains(text(),'TCLP')]/../..//input[@type='radio' and ./following-sibling::span[text()='" + valueToSet + "']]/parent::label"), 2);
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
				var rows = this.MetalContainers;
				Report.Info("There are " + rows.Count + " Metal Presence rows displayed");
				foreach (var metalRow in this.MetalContainers)
				{
					var metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"), 2)?.Text;
					var selectedOption = metalRow.FindElements(By.XPath(".//div[@class='radio']//input"), 2)?.First(x => x.Selected);
					var metalPresence = selectedOption?.FindElement(By.XPath("../span"), 2)?.Text;
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
				var header = this.MetalHeader;
				foreach (MetalPresence thisMetal in value)
				{
					var metalLabel = header.FindElements(By.XPath("../../following::div//label[@class='control-label']")).FirstOrDefault(x => x.GetValue().Trim() == thisMetal.Metal);
					var inputLabel = metalLabel.FindElements(By.XPath("../..//input/../span")).FirstOrDefault(x => x.Text == thisMetal.Presence);

					if (inputLabel != null)
					{
						try
						{
							var metalInput = inputLabel.FindElement(By.XPath("../input"));
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
			var circuit = this.MetalHeader;
			foreach (var metalRow in this.MetalContainers)
			{
				listOfMetals.Add(metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"),2)?.Text);
			}
			return listOfMetals;
		}

		public bool WaitForMetalSection(int secondsToWait)
		{
			for (int i = 0; i < secondsToWait; i++)
			{
				var header = SeleniumBrowser.WebBrowser.FindElements(By.XPath(".//div")).FirstOrDefault(x => x.Text.Contains("following metals"));
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

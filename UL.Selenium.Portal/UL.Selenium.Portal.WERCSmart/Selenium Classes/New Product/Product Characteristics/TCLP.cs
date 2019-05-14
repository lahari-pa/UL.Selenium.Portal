using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class TCLP : NewProduct
	{
		private IWebElement MetalHeader => this.containerElement.FindElement(By.XPath(""));

		public bool ProductHasTclp {
			get
			{
				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../following-sibling::div//label")).FirstOrDefault(x => !x.GetCssValue("background-color").Contains("255, 255, 255"));

				if (selectOption != null)
				{
					string selectedOption = selectOption.FindElement(By.XPath(".//span")).Text.Trim();
					Report.Info("Selected option is: " + selectedOption);
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

				var selectOption = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TCLP"))
					.FindElements(By.XPath("../..//label")).FirstOrDefault(x => x.Text == valueToSet);
				selectOption.Click();


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
				var listOfMetals = new List<MetalPresence>();
				var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

				var listOfMetalRows = header.FindElements(By.XPath("../../following-sibling::div"));
				foreach (var metalRow in listOfMetalRows)
				{
					try
					{
						string metalName = "";
						string presence = "";
						metalRow.ScrollElementIntoView();
						Delay.Seconds(1);
						metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
						var presenceA = metalRow.FindElements(By.XPath(".//div[@class='radio']//input"));

						var presenceB = presenceA.Where(x => x.Selected == true).ToList().FirstOrDefault();

						if (presenceB != null)
						{
							presence = presenceB.FindElement(By.XPath("../span")).Text;
							Report.Info("Adding metal: " + metalName + ": " + presence);
							listOfMetals.Add(new MetalPresence(metalName, presence));
						}
						else
						{
							listOfMetals.Add(new MetalPresence(metalName, "none"));
						}

					}
					catch (Exception e)
					{
						Report.Info(e.Message);
					}

				}

				return listOfMetals;
			}
			set
			{
				Report.Info(value.Count.ToString() + " metals to set.");
				var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

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
						catch (Exception e)
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
			var circuitDiv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));
			var listOfMetalRows = circuitDiv.FindElements(By.XPath("../../following-sibling::div"));
			foreach (var metalRow in listOfMetalRows)
			{
				listOfMetals.Add(metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"))?.Text);
			}
			return listOfMetals;
		}
	}
}

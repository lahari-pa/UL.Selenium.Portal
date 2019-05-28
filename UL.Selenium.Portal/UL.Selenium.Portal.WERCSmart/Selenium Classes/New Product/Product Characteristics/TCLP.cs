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
		private IWebElement MetalHeader => this.containerElement.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));

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
				var listOfMetals = new List<MetalPresence>();
				//var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));
				var header = this.MetalHeader;
				var metalRows = header.FindElements(By.XPath("../../following-sibling::div"));
				foreach (var metalRow in metalRows)
				{
					try
					{
						string metalName = "";
						metalRow.ScrollElementIntoView();
						Delay.Seconds(1);
						metalName = metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label")).Text;
						var presenceA = metalRow.FindElements(By.XPath(".//div[@class='radio']//input"));

						var presenceB = presenceA.Where(x => x.Selected == true).ToList().FirstOrDefault();

						if (presenceB != null)
						{
							string presence = presenceB.FindElement(By.XPath("../span")).Text;
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
				Report.Info(value.Count + " metals to set.");
				//var header = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));
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
			//var circuitDiv = SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//div[@class='form-group']//div[contains(text(), 'Circuit')]"));
			var circuit = this.MetalHeader;
			var listOfMetalRows = circuit.FindElements(By.XPath("../../following-sibling::div[not(@style='display: none;')]"),2).ToList();
			foreach (var metalRow in listOfMetalRows)
			{
				listOfMetals.Add(metalRow.FindElement(By.XPath(".//div[@class='radio']/../preceding-sibling::div/label"),2)?.Text);
			}
			return listOfMetals;
		}
	}
}

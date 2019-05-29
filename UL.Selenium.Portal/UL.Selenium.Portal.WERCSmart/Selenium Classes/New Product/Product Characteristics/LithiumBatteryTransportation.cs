using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Automation_Classes.Extension_Methods;
using NTTQA_Reporting_Module.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class LithiumBatteryTransportation : NewProduct
	{

		public string Dot {
			get => this.SelectedOptionForLabel("DOT");
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("DOT"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label DOT could not be found");
				}
			}
		}

		public string Imdg {
			get => this.SelectedOptionForLabel("IMDG");
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IMDG"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label IMDG could not be found");
				}
			}
		}

		public string Iata {
			get => this.SelectedOptionForLabel("IATA");
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("IATA"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label IATA could not be found");
				}
			}
		}

		public string Tdg {
			get => this.SelectedOptionForLabel("TDG");
			set
			{
				var lbl = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TDG"));

				if (lbl != null)
				{
					var thisLabel = lbl.FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text.Contains(value));
					if (thisLabel != null)
					{
						var thisInput = thisLabel.FindElement(By.XPath(".//../input"));
						if (!thisInput.Selected)
						{
							thisInput.Click();
						}
					}
					else
					{
						throw new Exception("Label for: " + value + " could not be found");
					}
				}
				else
				{
					throw new Exception("Label TDG could not be found");
				}
			}
		}

		public string TscaStatus {
			get
			{
				var listOfOptions = this.containerElement.FindElements(By.XPath(".//label"), 2)
					.FirstOrDefault(x => x.Text.Contains("TSCA"))
					.FindElements(By.XPath("../..//input"));
				foreach (var item in listOfOptions)
				{
					if (item.Selected)
					{
						return item.FindElement(By.XPath("../..//label")).Text;
					}
				}
				return "";
			}
			set
			{
				var thisLabel = this.containerElement.FindElements(By.XPath(".//label"), 2).FirstOrDefault(x => x.Text.Contains("TSCA")).FindElements(By.XPath("../..//input/../../label/span")).FirstOrDefault(y => y.Text == value);
				var optionInput = thisLabel.FindElement(By.XPath(".//../input"));
				if (!optionInput.Selected)
				{
					optionInput.Click();
				}
			}
		}

	}
}

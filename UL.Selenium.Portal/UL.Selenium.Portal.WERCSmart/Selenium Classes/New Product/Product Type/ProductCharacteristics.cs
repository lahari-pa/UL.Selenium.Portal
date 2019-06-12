using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class ProductCharacteristics : NewProduct
	{
		/// <summary>
		/// Specific Gravity text box
		/// </summary>
		public string SpecificGravity {
			get => this.TextInputValueForLabel("Specific Gravity");
			set => this.SetOptionInSection("Specific Gravity", value);
		}

		/// <summary>
		/// pH text box
		/// </summary>
		public string PH {
			get => this.TextInputValueForLabel("pH");
			set => this.SetOptionInSection("pH", value);
		}

		/// <summary>
		/// Boiling Point (in Celsius) text box
		/// </summary>
		public string BoilingPoint {
			get => this.TextInputValueForLabel("Boiling Point (in Celsius)");
			set => this.SetOptionInSection("Boiling Point (in Celsius)", value);
		}

		/// <summary>
		/// Flash Point (in Celsius) text box
		/// </summary>
		public string FlashPoint {
			get => this.TextInputValueForLabel("Flash Point (in Celsius)");
			set => this.SetOptionInSection("Flash Point (in Celsius)", value);
		}

		public string PrimaryPhysicalState {
			get => this.SelectedInputForLabel("Primary Physical State");
			set => this.SelectRadio("Primary Physical State", value);

			//try
			//{
			//	var el = this.containerElement
			//		.FindElements(By.XPath(".//label[text()='Primary Physical State']/../following-sibling::div//span"), 2)
			//		.FirstOrDefault(x => x.Text.ToLower() == item.ToLower()).FindElement(By.XPath("../input"));
			//	if (el != null)
			//	{
			//		el.TryClick();
			//		return true;
			//	}

			//	return false;
			//}
			//catch (Exception)
			//{
			//	return false;
			//}
		}

		/// <summary>
		/// Select the best Water Solubility description dropdown
		/// </summary>
		//public bool SelectBestWaterSolubilityDescription(string item)
		//{
		//	try
		//	{
		//		var el = this.containerElement.FindElement(By.XPath(".//label[text()='Select the best Water Solubility description']/..//following-sibling::div//select"), 2);
		//		el.Select(item);
		//		return true;
		//	}
		//	catch (Exception)
		//	{
		//		return false;
		//	}
		//}

		public string BestWaterSolubilityDescription {
			get { return null; }
			set
			{

			}
		}
	}
}

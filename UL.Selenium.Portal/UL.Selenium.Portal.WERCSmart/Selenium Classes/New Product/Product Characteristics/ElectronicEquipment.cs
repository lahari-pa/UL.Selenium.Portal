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
	class ElectronicEquipment : NewProduct
	{
		public bool HasLcdOrPlasmaDisplay {
			get => this.SelectedRadioForBtnLabel("Plasma Display") == "Yes";
			set
			{
				var textValue = value ? "Yes" : "No";
				this.SelectRadio("Plasma Display", textValue);
			}
		}

		public bool ContainsCircuitBoard {
			get => this.SelectedRadioForBtnLabel("Circuit Board") == "Yes";
			set
			{
				var textValue = value ? "Yes" : "No";
				this.SelectRadio("Contains Circuit Board", textValue);
			}
		}

	}
}

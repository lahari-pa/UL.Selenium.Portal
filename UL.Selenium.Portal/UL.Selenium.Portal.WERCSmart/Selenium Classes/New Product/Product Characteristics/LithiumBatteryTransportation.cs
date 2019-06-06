using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class LithiumBatteryTransportation : NewProduct
	{

		public string Dot {
			get => this.SelectedInputForLabel("DOT");
			set => this.SelectRadio("DOT", value);
		}

		public string Imdg {
			get => this.SelectedInputForLabel("IMDG");
			set => this.SelectRadio("IMDG", value);
		}

		public string Iata {
			get => this.SelectedInputForLabel("IATA");
			set => this.SelectRadio("IATA", value);
		}

		public string Tdg {
			get => this.SelectedInputForLabel("TDG");
			set => this.SelectRadio("TDG", value);
		}

	}
}

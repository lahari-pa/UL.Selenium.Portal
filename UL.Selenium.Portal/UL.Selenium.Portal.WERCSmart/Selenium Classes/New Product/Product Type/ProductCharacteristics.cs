namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product
{
	class ProductCharacteristics : NewProduct
	{
		/// <summary>
		/// Relative Density text box
		/// </summary>
		public string SpecificGravity {
			get => this.TextInputValueForLabel("Relative Density");
			set => this.SetOptionInSection("Relative Density", value);
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
		}

		public string BestWaterSolubilityDescription {
			get => this.SelectedInputForLabel("Best Water Solubility");
			set => this.SetOptionInSection("Best Water Solubility", value);

		}
	}
}

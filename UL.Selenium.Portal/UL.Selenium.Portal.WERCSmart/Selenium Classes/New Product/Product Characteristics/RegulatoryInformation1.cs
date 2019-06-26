namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class RegulatoryInformation1 : NewProduct
	{
		public string TscaStatus {
			get => this.SelectedInputForLabel("TSCA");
			set => this.SelectRadio("TSCA", value);
		}

		public bool Prop65 {
			get
			{
				var prop = this.CheckedInputForLabel("Prop 65") ?? this.CheckedInputForLabel("Proposition 65");
				return prop == "Yes";
			}
			set
			{
				var valueToSet = value ? "Yes" : "No";
				if (!this.SelectRadio("Prop 65", valueToSet))
				{
					this.SelectRadio("Proposition 65", valueToSet);
				}
			}
		}
	}
}

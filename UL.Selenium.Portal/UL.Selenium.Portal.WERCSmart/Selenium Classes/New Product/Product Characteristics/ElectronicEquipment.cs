namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	class ElectronicEquipment : NewProduct
	{
		public bool HasLcdOrPlasmaDisplay {
			get => this.CheckedInputForLabel("Plasma Display") == "Yes";
			set
			{
				string textValue = value ? "Yes" : "No";
				this.SelectRadio("Plasma Display", textValue);
			}
		}

		public bool ContainsCircuitBoard {
			get => this.CheckedInputForLabel("Circuit Board") == "Yes";
			set
			{
				string textValue = value ? "Yes" : "No";
				this.SelectRadio("Contains Circuit Board", textValue);
			}
		}

	}
}

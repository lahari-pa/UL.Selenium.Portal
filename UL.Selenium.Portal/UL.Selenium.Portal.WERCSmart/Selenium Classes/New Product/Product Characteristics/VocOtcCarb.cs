using OpenQA.Selenium;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	public class VocOtcCarb : NewProduct
	{
		#region Label constants
		public new string PanelTitle = "Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)";



		private const string _grantedAcpQuestion = "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.";
		//private const string _grantedAcpQuestion = "Product has been granted";

		private const string _labelDilutionQuestion = "Product label specifies a dilution ratio which results in a final VOC concentration for the product during use";

		private const string _vocContentAsSoldQuestion = "Product's VOC content as sold";

		private const string _vocContentAsUsedQuestion = "Product's VOC content as used";

		private const string _hvocContentQuestion = "HVOC (high volatile organic compound) content as weight percent of the total formulation";

		private const string _mvocContentQuestion = "MVOC (microbial volatile organic compound) content as weight percentage of the total formulation";

		#endregion

		#region Get or set data inputs
		public bool GrantedAlternativeControlPlan
		{
			get => this.SelectedRadioForLabel(_grantedAcpQuestion) == "Yes";
			set
			{
				if (value)
				{
					this.SelectRadio(_grantedAcpQuestion, "Yes");
					return;
				}
				this.SelectRadio(_grantedAcpQuestion, "No");
			}
		}

		public bool LabelDilutionRatio
		{
			get => this.SelectedRadioForLabel(_labelDilutionQuestion) == "Yes";
			set
			{
				if (value)
				{
					this.SelectRadio(_labelDilutionQuestion, "Yes");
					return;
				}
				this.SelectRadio(_labelDilutionQuestion, "No");
			}
		}

		public string VocContentAsSold
		{
			get => this.TextInputValueForLabel(_vocContentAsSoldQuestion);
			set => this.EnterTextToLabelnput(_vocContentAsSoldQuestion, value);
		}

		public string VocContentAsUsed
		{
			get => this.TextInputValueForLabel(_vocContentAsUsedQuestion);
			set => this.EnterTextToLabelnput(_vocContentAsUsedQuestion, value);
		}

		public string HvocContent
		{
			get => this.TextInputValueForLabel(_hvocContentQuestion);
			set => this.EnterTextToLabelnput(_hvocContentQuestion, value);
		}

		public string MvocContent
		{
			get => this.TextInputValueForLabel(_mvocContentQuestion);
			set => this.EnterTextToLabelnput(_mvocContentQuestion, value);
		}
		#endregion

		#region Error messages

		public string VocContentAsSoldError() => this.GetErrorForSection(_vocContentAsSoldQuestion);

		public string VocContentAsUsedError() => this.GetErrorForSection(_vocContentAsUsedQuestion);

		#endregion

		#region IWebElement Methods

		public bool SelectAgreeInVOCAcceptance()
		{
			IWebElement checkBox = this.containerElement.FindElement(By.XPath("//span[contains(text(), 'Your acknowledgement of this registration includes that your product (exceeds/does not exceed) the limits specified by the noted regulations and understand these statements of exceeding, or not exceeding, will be provided to the recipients for which the product is registered and assessed.  Recipients may take action based on these statements.')]/preceding-sibling::input"), 2);
			return checkBox.TryClick();

		}

		#endregion
	}

}

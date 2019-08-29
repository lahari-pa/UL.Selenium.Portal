using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics
{
	public class VOC_OTC_CARB : NewProduct
	{
		#region Label Definitions
		public new string PanelTitle = "Volatile Organic Compounds (VOC) - Ozone Transport Commission (OTC) and/or California Air Resources Board (CARB)";

		public string GrantedAcpQuestion = "Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.";

		private const string _labelDilutionQuestion = "Product label specifies a dilution ratio which results in a final VOC concentration for the product during use";

		private const string _vocContentAsSoldQuestion = "Product's VOC content as sold";

		private const string _vocContentAsUsedQuestion = "Product's VOC content as used";

		#endregion

		public bool GrantedAlternativeControlPlan {
			get => this.SelectedInputForLabel(this.GrantedAcpQuestion) == "Yes";
			set
			{
				if (value)
				{
					this.SelectRadio(this.GrantedAcpQuestion, "Yes");
					return;
				}
				this.SelectRadio(this.GrantedAcpQuestion, "No");
			}
		}

		public bool LabelDilutionRatio {
			get => this.SelectedInputForLabel(_labelDilutionQuestion) == "Yes";
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

		public string VocContentAsSold {
			get => this.TextInputValueForLabel(_vocContentAsSoldQuestion);
			set => this.EnterTextToLabelnput(_vocContentAsSoldQuestion, value);
		}

		public string VocContentAsUsed {
			get => this.TextInputValueForLabel(_vocContentAsUsedQuestion);
			set => this.EnterTextToLabelnput(_vocContentAsUsedQuestion, value);
		}


	}
}

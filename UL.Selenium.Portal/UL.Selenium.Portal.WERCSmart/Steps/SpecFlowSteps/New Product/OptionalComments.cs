using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:RewiewAndSubmit_Section:OptionalComments")]
	class WERCSmart_NewProducts_ProductType_OptionalComments
	{
		[RegexStepDefinition(@"In the Optional Comments Section, in 'Provide any additional comments or information about the product that you want the Assessment Team to know.' enter comment (.*)")]
		public void SelectPublicResponsibilityForProduct(string text)
		{
			new Steps_Prototype().ThenIEnterTheFollowingIntoTheCommentsFieldCommentsFieldText(text);
		}
	}
}

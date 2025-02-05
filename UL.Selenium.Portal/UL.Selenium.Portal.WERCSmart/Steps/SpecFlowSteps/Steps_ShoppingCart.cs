using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Automation.ReqnrollHelpers.Attributes;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "CartPage")]
	class Steps_ShoppingCart
	{
		[RegexStepDefinition(@"In the Shopping Cart, Validate popup when cart is empty")]
		public void CValidatePopupWhenCartIsEmpty()
		{
			GeneralUtilities.Wait_for_load_finish();
			Report.Info("Checking that Cart is Empty window appears");
			var selCartEmpty = new CartIsEmptyDialog();
			string showing = selCartEmpty.HeaderShowing();
			Report.IsTrue(showing == "Cart is Empty",$"Cart is Empty header was not as expected!but found: '{showing}' instead!",
					"Cart is Empty header was showing 'Cart is Empty', as expected!");
		}


	}
}

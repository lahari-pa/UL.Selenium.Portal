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
		[RegexStepDefinition(@"In the Shopping Cart, Validate empty cart popup (should| should not) be displayed")]
		public void ValidatePopupWhenCartIsEmpty(string condition)
		{
			string title = "Cart is Empty";
			string text = "There are no items in the shopping cart.";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}

		[RegexStepDefinition(@"In the Shopping cart, in the 'empty cart' pop up click Close button")]
		public void ClickCloseInRemoveDocumentPopUp()
		{
			string popupTitle = "Cart is Empty";
			string button = "Close";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}


	}
}

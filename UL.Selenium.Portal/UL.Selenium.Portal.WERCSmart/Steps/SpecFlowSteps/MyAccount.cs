using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:MyAccount")]
	class WERCSmart_MyAccount
	{
		[RegexStepDefinition(@"In the My Account section, click the 'Company Information' link")]
		public void ClickTheCompanyInformationLink()
		{
			string linkText = "Company Information";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Subscription Information' link")]
		public void ClickTheSubscriptionInformationLink()
		{
			string linkText = "Subscription Information";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Payment Methods' link")]
		public void ClickThePaymentMethodsLink()
		{
			string linkText = "Payment Methods";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Order History' link")]
		public void ClickTheOrderHistoryLink()
		{
			string linkText = "Order History";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'My Library' link")]
		public void ClickTheMyLibraryLink()
		{
			string linkText = "My Library";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Subscription Price List' link")]
		public void ClickTheSubscriptionPriceListLink()
		{
			string linkText = "Subscription Price List";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[RegexStepDefinition(@"In the My Account section, click the 'Invite New User' link")]
		public void ClickTheInviteNewUserLink()
		{
			string linkText = "Invite New User";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
	}
}

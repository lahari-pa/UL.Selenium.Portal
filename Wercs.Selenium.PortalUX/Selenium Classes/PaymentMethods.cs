using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;
using Global = SeleniumUtilities.Global;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class PaymentMethods : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "paymentMethodsContainer")]
		protected override IWebElement containerElement { get; set; }








	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumUtilities;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class UlSolutionCenter : BaseObject
	{
		public const string BasePath = "//div[@id='solutionCenterContainer']";
		[FindsBy(How = How.XPath, Using = BasePath)]
		protected override IWebElement containerElement { get; set; }

		public string HeaderShowing()
		{
			return this.containerElement.FindElement(By.XPath("..//h2"), 2).Text;
		}

		/// <summary>
		/// Gets the list of options Ecologo, Prospector, GoodGuide for Consumers, GoodGuide for Suppliers, ULSC and ULGHS
		/// </summary>
		/// <returns></returns>
		public List<string> OptionShowing()
		{
			return this.containerElement.FindElements(By.XPath(".//h3"), 2).Where(x => x.Displayed).Select(x => x.Text.Trim()).ToList();
		}

		/// <summary>
		/// Clicks the ECOLogo Learn more button
		/// </summary>
		public void ClickEcologoLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://industries.ul.com/environment/certificationvalidation-marks/ecologo-product-certification']"), 2);
		}

		/// <summary>
		/// Clicks the Prospector Learn more button
		/// </summary>
		public void ClickProspectorLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://www.ulprospector.com/']"), 2);
		}

		/// <summary>
		/// Clicks the GoodGuide for Consumers Learn more button
		/// </summary>
		public void ClickGoodGuideForConsumersLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://goodguide.com/']"), 2);
		}

		/// <summary>
		/// Clicks the GoodGuide for Suppliers Learn more button
		/// </summary>
		public void ClickGoodGuideForSuppliersLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://choosegoodguide.com/']"), 2);
		}

		/// <summary>
		/// Clicks the UL Secure Connect Learn more button
		/// </summary>
		public void ClickUlSecureConnectLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://ul-scs.com/wercslink/']"), 2);
		}

		/// <summary>
		/// Clicks the ULGHS Learn more button
		/// </summary>
		public void ClickUlGhSLearnMore()
		{
			this.containerElement.FindElement(By.XPath(".//a[contains(@class,'btn btn-default pull-right') and @href='https://www.ulghs.com/']"), 2);
		}
	}

}
